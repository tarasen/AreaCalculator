namespace AreaCalculator.Figures
{
    #region usings

    using System;

    #endregion

    public class Circle : IHasArea
    {
        internal Circle(double radius) 
            => Radius = radius;

        public double Radius { get; }

        public virtual double CalculateArea() 
            => Math.PI * Radius * Radius;
    }
}