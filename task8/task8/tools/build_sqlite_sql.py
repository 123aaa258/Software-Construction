from __future__ import annotations

import re
from pathlib import Path


SCRIPT_DIR = Path(__file__).resolve().parent
PROJECT_DIR = SCRIPT_DIR.parent
SOURCE_DIR = PROJECT_DIR.parent / "vocabulary_from_github" / "english-vocabulary"
OUTPUT_FILE = PROJECT_DIR / "sql" / "init_words.sql"
TXT_PATTERN = "*乱序.txt"


def escape_sqlite_text(value: str) -> str:
    return value.replace("'", "''")


def get_level_from_filename(file_name: str) -> str:
    match = re.match(r"\d+\s+(.+)-乱序\.txt$", file_name)
    if match is None:
        raise ValueError("无法从文件名提取词库级别: {0}".format(file_name))
    return match.group(1).strip()


def parse_vocabulary_file(file_path: Path) -> list[tuple[str, str, str]]:
    level = get_level_from_filename(file_path.name)
    rows = []

    with file_path.open("r", encoding="utf-8") as file_obj:
        for line_number, raw_line in enumerate(file_obj, start=1):
            line = raw_line.strip()
            if not line:
                continue

            parts = line.split("\t", 1)
            if len(parts) != 2:
                raise ValueError(
                    "文件 {0} 第 {1} 行格式错误，预期为 `单词\\t释义`".format(file_path, line_number)
                )

            english = parts[0].strip()
            chinese = parts[1].strip()
            if not english or not chinese:
                continue

            rows.append((level, english, chinese))

    return rows


def build_sql(rows: list[tuple[str, str, str]]) -> str:
    sql_lines = [
        "PRAGMA foreign_keys = OFF;",
        "DROP TABLE IF EXISTS Words;",
        "CREATE TABLE Words (",
        "    Id INTEGER PRIMARY KEY AUTOINCREMENT,",
        "    Level TEXT NOT NULL,",
        "    English TEXT NOT NULL,",
        "    Chinese TEXT NOT NULL",
        ");",
        "",
        "BEGIN TRANSACTION;",
    ]

    for level, english, chinese in rows:
        sql_lines.append(
            "INSERT INTO Words (Level, English, Chinese) VALUES ('{0}', '{1}', '{2}');".format(
                escape_sqlite_text(level),
                escape_sqlite_text(english),
                escape_sqlite_text(chinese),
            )
        )

    sql_lines.append("COMMIT;")
    sql_lines.append("")
    return "\n".join(sql_lines)


def main() -> None:
    txt_files = sorted(SOURCE_DIR.glob(TXT_PATTERN), key=lambda item: item.name)
    if not txt_files:
        raise FileNotFoundError("未找到词库 txt 文件: {0}".format(SOURCE_DIR))

    all_rows = []
    for txt_file in txt_files:
        all_rows.extend(parse_vocabulary_file(txt_file))

    OUTPUT_FILE.parent.mkdir(parents=True, exist_ok=True)
    OUTPUT_FILE.write_text(build_sql(all_rows), encoding="utf-8")

    print("Generated: {0}".format(OUTPUT_FILE))
    print("Total words: {0}".format(len(all_rows)))


if __name__ == "__main__":
    main()
