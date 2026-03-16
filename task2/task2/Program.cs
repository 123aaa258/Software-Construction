using System;
using System.Collections.Generic;

namespace task2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random random = new Random();
            List<Shape> shapes = new List<Shape>();
            double totalArea = 0;
            int i;

            for (i = 0; i < 10; i++)
            {
                shapes.Add(CreateRandomShape(random));
            }

            Console.WriteLine("随机创建的10个图形如下：");
            Console.WriteLine();

            for (i = 0; i < shapes.Count; i++)
            {
                Shape shape = shapes[i];
                bool isValid = shape.IsValid();
                double area = shape.GetArea();

                Console.WriteLine("第{0}个图形：{1}", i + 1, shape.GetShapeInfo());
                Console.WriteLine("是否合法：{0}", isValid ? "是" : "否");

                if (isValid)
                {
                    Console.WriteLine("面积：{0:F2}", area);
                    totalArea += area;
                }
                else
                {
                    Console.WriteLine("面积：非法图形，无法计算");
                }

                Console.WriteLine();
            }

            Console.WriteLine("10个图形的面积之和：{0:F2}", totalArea);
        }

        private static Shape CreateRandomShape(Random random)
        {
            int shapeType = random.Next(4);

            switch (shapeType)
            {
                case 0:
                    return new Rectangle(GetRandomLength(random), GetRandomLength(random));
                case 1:
                    return new Square(GetRandomLength(random));
                case 2:
                    return new Circle(GetRandomLength(random));
                default:
                    return new Triangle(GetRandomLength(random), GetRandomLength(random), GetRandomLength(random));
            }
        }

        private static double GetRandomLength(Random random)
        {
            return random.Next(1, 11) + random.NextDouble();
        }
    }
}
