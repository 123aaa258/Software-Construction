using System;

namespace task2
{
    public class Triangle : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override bool IsValid()
        {
            return A > 0 && B > 0 && C > 0
                && A + B > C
                && A + C > B
                && B + C > A;
        }

        public override double GetArea()
        {
            double p;

            if (!IsValid())
            {
                return 0;
            }

            p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public override string GetShapeInfo()
        {
            return string.Format("三角形(边1={0:F2}, 边2={1:F2}, 边3={2:F2})", A, B, C);
        }
    }
}
