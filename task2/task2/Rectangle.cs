using System;

namespace task2
{
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override bool IsValid()
        {
            return Length > 0 && Width > 0;
        }

        public override double GetArea()
        {
            if (!IsValid())
            {
                return 0;
            }

            return Length * Width;
        }

        public override string GetShapeInfo()
        {
            return string.Format("长方形(长={0:F2}, 宽={1:F2})", Length, Width);
        }
    }
}
