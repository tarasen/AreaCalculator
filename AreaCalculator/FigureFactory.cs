namespace AreaCalculator
{
    #region usings
    
    using System;

    using global::AreaCalculator.Figures;

    #endregion usings

    public class FigureFactory
    {
        public Circle CreateCircle(double radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException("Radius can't be negative", nameof(radius));

            return new Circle(radius);
        }

        public Triangle CreateTriangle(double a, double b, double c)
        {
            if (!CheckZeroEdge(a, b, c))
                throw new ArgumentOutOfRangeException("Triangle edge can't be zero or negative");

            if (!CheckTriangleRule(a, b, c))
                throw new ArgumentException("There is no triangle with this edges");

            if (CheckIsRight(a, b, c))
            {
                if (a > b && a > c)
                    return new RightTriangle(b, c, a);
                if (b > a && b > c)
                    return new RightTriangle(a, c, b);

                return new RightTriangle(a, b, c);
            }

            return new Triangle(a, b, c);


            bool CheckZeroEdge(double edgeA, double edgeB, double edgeC) 
                => edgeA > 0 && edgeB > 0 && edgeC > 0;

            bool CheckTriangleRule(double edgeA, double edgeB, double edgeC) 
                => edgeA + edgeB > edgeC && edgeA + edgeC > edgeB && edgeB + edgeC > edgeA;

            bool CheckIsRight(double edgeA, double edgeB, double edgeC)
            {
                var doubleA = edgeA * edgeA;
                var doubleB = edgeB * edgeB;
                var doubleC = edgeC * edgeC;

                return FloatingPointEquality(doubleA + doubleB, doubleC) 
                       || FloatingPointEquality(doubleA + doubleC, doubleB) 
                       || FloatingPointEquality(doubleB + doubleC, doubleA);
                

                bool FloatingPointEquality(double x, double y, double eps = float.Epsilon) => Math.Abs(x - y) < eps;
            }
        }
    }
}