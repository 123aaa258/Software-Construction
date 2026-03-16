using System;

namespace task2
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override bool IsValid()
        {
            return Radius > 0;
        }

        public override double GetArea()
        {
            if (!IsValid())
            {
                return 0;
            }

            return Math.PI * Radius * Radius;
        }

        public override string GetShapeInfo()
        {
            return string.Format("圆形(半径={0:F2})", Radius);
        }
    }
}
