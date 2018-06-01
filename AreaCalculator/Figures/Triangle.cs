namespace AreaCalculator.Figures
{
    #region usings

    using System;

    #endregion

    public class Triangle : IHasArea
    {
        internal Triangle(double a, double b, double c)
        {
            EdgeA = a;
            EdgeB = b;
            EdgeC = c;
        }

        public double EdgeA { get; }

        public double EdgeB { get; }

        public double EdgeC { get; }

        public virtual double CalculateArea()
        {
            return HeronsFormula(CalculatePerimeter() / 2.0);

            double HeronsFormula(double p) => Math.Sqrt(p * (p - EdgeA) * (p - EdgeB) * (p - EdgeC));

            double CalculatePerimeter() => EdgeA + EdgeB + EdgeC;
        }
    }
}