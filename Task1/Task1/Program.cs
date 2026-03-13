// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("你好！我是马士帅");

Console.Write("请输入下限：");
int lower = int.Parse(Console.ReadLine()!);

Console.Write("请输入上限：");
int upper = int.Parse(Console.ReadLine()!);

if (lower > upper)
{
    int temp = lower;
    lower = upper;
    upper = temp;
}

int count = 0;

for (int i = lower; i <= upper; i++)
{
    if (IsPrime(i))
    {
        Console.Write($"{i}\t");
        count++;

        if (count % 10 == 0)
        {
            Console.WriteLine();
        }
    }
}

if (count == 0)
{
    Console.WriteLine("该范围内没有素数。");
}
else if (count % 10 != 0)
{
    Console.WriteLine();
}

static bool IsPrime(int n)
{
    if (n < 2)
    {
        return false;
    }

    for (int i = 2; i * i <= n; i++)
    {
        if (n % i == 0)
        {
            return false;
        }
    }

    return true;
}
