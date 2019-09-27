using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace CalculatorLibTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestCategory("InputData")]
        public void PressPlusTwoItem()
        {
            // Arrange.
            var value1 = 1;
            var value2 = 2;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressPlus();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressMultiplyTwoItem()
        {
            // Arrange.
            var value1 = 1;
            var value2 = 2;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressMultiply();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressDivideMultiplyTwoItem()
        {
            // Arrange.
            var value1 = 1;
            var value2 = 17;
            var value3 = 34;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressDivide();
            calculator.PressDisplay(value2);
            calculator.PressMultiply();
            calculator.PressDisplay(value3);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        [ExpectedException(typeof(DivideByZeroException))]
        public void PressDivideZeroTwoItem()
        {
            // Arrange.
            var value1 = 1;
            var value2 = 0;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressDivide();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressDivideTwoItem()
        {
            // Arrange.
            var value1 = 1;
            var value2 = 2;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressDivide();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 0.5;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [TestCategory("InputData")]
        public void PressPlusThreeItem()
        {
            // Arrange.
            var value1 = 1;
            var value2 = 2;
            var value3 = 3;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressPlus();
            calculator.PressDisplay(value2);
            calculator.PressPlus();
            calculator.PressDisplay(value3);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressMinusTwoItem()
        {
            // Arrange.
            var value1 = 3;
            var value2 = 2;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressMinus();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressMinusThreeItem()
        {
            // Arrange.
            var value1 = 3;
            var value2 = 2;
            var value3 = 2;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressMinus();
            calculator.PressDisplay(value2);
            calculator.PressMinus();
            calculator.PressDisplay(value3);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressPlusMinusThreeItem()
        {
            // Arrange.
            var value1 = 3;
            var value2 = 2;
            var value3 = 2;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressPlus();
            calculator.PressDisplay(value2);
            calculator.PressMinus();
            calculator.PressDisplay(value3);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressMinusPlusThreeItem()
        {
            // Arrange.
            var value1 = 3;
            var value2 = 2;
            var value3 = 1;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressMinus();
            calculator.PressDisplay(value2);
            calculator.PressPlus();
            calculator.PressDisplay(value3);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OutputData")]
        public void OutPositiveValue()
        {
            PressMinusPlusThreeItem();
        }

        [TestMethod]
        [TestCategory("OutputData")]
        public void OutNegativeValue()
        {
            PressMinusThreeItem();
        }

        [TestMethod]
        [TestCategory("OutputData")]
        public void OutZero()
        {
            // Arrange.
            var value1 = 1;
            var value2 = 1;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressMinus();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("LengthInputData")]
        public void PresPlusTenItem()
        {
            // Arrange.
            var array = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Act.
            var calculator = new Calculator();
            foreach (var item in array)
            {
                calculator.PressDisplay(item);
                calculator.PressPlus();
            }
            var actual = calculator.Display;
            // Assert.
            var expected = 55;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("LengthInputData")]
        public void PresPlusHundredItem()
        {
            // Arrange.

            // Act.
            var calculator = new Calculator();
            Random rnd = new Random(42);
            double expected = 0;
            for (int i = 0; i < 100; i++)
            {
                var item = (double)rnd.Next(100);
                expected += item;
                calculator.PressDisplay(item);
                calculator.PressPlus();
            }
            var actual = calculator.Display;
            // Assert.
            Assert.AreEqual(expected, actual);
        }
    }
}
