namespace AreaCalculator
{
    #region usings

    using System;

    #endregion usings

    public class AreaCalculator
    {
        public double GetArea(IHasArea figure)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));

            return figure.CalculateArea();
        }
    }
}