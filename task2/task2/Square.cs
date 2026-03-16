using System;

namespace task2
{
    public class Square : Shape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public override bool IsValid()
        {
            return SideLength > 0;
        }

        public override double GetArea()
        {
            if (!IsValid())
            {
                return 0;
            }

            return SideLength * SideLength;
        }

        public override string GetShapeInfo()
        {
            return string.Format("正方形(边长={0:F2})", SideLength);
        }
    }
}
