using System;

namespace task2
{
    public abstract class Shape : IShape
    {
        public abstract bool IsValid();
        public abstract double GetArea();
        public abstract string GetShapeInfo();
    }
}
