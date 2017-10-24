using System;
using System.Dynamic;
using FirstEx;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstExTests
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void shouldCreateCircle()
        {
            Circle circle = new Circle(6, "red", 10);
        }

        [TestMethod]
        public void shouldFailCreatingCircleRadiusLowerThanZero()
        {
            Action action = () => new Circle(-1,"red", 10);
            action.ShouldThrow<ArgumentException>().WithMessage("radius must be greater than 0");
        }

        [TestMethod]
        public void shouldFailCreatingCircleTransparencyGreaterThanOneHundred()
        {
            Action action = () => new Circle(10, "red", 101);
            action.ShouldThrow<ArgumentException>().WithMessage("transparency must be between 0 and 100");
        }

        [TestMethod]
        public void shouldReturnDrawCircle()
        {
            Circle circle= new Circle(10, "red", 99);
            circle.Draw().Should().Be("Draw Circle");
        }

        [TestMethod]
        public void shouldReturnArea()
        {
            Circle circle = new Circle(20, "red", 99);
            circle.ComputeArea().Should().Be(3.14*20*20);
        }

        [TestMethod]
        public void shouldNotBeVisible()
        {
            Circle circle = new Circle(20, "red", 99);
            circle.isVisible().Should().Be(false);
        }
    }
}

