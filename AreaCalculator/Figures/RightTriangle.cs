namespace AreaCalculator.Figures
{
    public class RightTriangle : Triangle
    {
        internal RightTriangle(double leg1, double leg2, double hypotenuse)
            : base(leg1, leg2, hypotenuse) { }

        public double Leg1 => EdgeA;

        public double Leg2 => EdgeB;

        public double Hypotenuse => EdgeC;

        public override double CalculateArea() 
            => Leg1 * Leg2 / 2.0;
    }
}