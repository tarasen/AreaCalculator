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
        private FigureFactory _factory;
        private AreaCalculator _calc;

        [SetUp]
        public void SetUp()
        {
            _factory = new FigureFactory();
            _calc = new AreaCalculator();
        }

        [TestCase(0, 0)] // just point
        [TestCase(1, Math.PI)]
        [TestCase(10, Math.PI * 100)]
        public void CalculateArea_SomeValues_MatchResult(double radius, double expected)
        {
            var circle = _factory.CreateCircle(radius);

            var area = _calc.GetArea(circle);

            area.Should().BeApproximately(expected, 1e-10);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(42)]
        public void CreateCircle_NormalRadius_Created(double radius)
        {
            var circle = _factory.CreateCircle(radius);

            circle.Should().BeOfType<Circle>().And.NotBeNull();
        }

        [TestCase(-4)]
        public void CreateCircle_WrongRadius_CantCreate(double radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _factory.CreateCircle(radius));
        }
    }
}