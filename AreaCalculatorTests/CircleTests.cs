namespace AreaCalculatorTests
{
    #region usings

    using System;

    using AreaCalculator;
    using AreaCalculator.Figures;

    using FluentAssertions;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    public class CircleTests
    {
        [TestCase(0, 0)] // just point
        [TestCase(1, Math.PI)]
        [TestCase(10, Math.PI * 100)]
        public void CalculateArea_SomeValues_MatchResult(double radius, double expected)
        {
            var factory = new FigureFactory();
            var circle = factory.CreateCircle(radius);

            var area = circle.CalculateArea();

            area.Should().BeApproximately(expected, 1e-10);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(42)]
        public void CreateCircle_NormalRadius_Created(double radius)
        {
            var factory = new FigureFactory();

            var circle = factory.CreateCircle(radius);

            circle.Should().BeOfType<Circle>().And.NotBeNull();
        }

        [TestCase(-4)]
        public void CreateCircle_WrongRadius_CantCreate(double radius)
        {
            var factory = new FigureFactory();

            Assert.Throws<ArgumentOutOfRangeException>(() => factory.CreateCircle(radius));
        }
    }
}