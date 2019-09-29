using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace CalculatorLibTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestCategory("Function")]
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(25.6, 25.6)]
        [DataRow(-100, -100)]
        [DataRow(-2.89, -2.89)]
        [DataRow(0, 0)]
        public void PressDisplay(double value, double expected)
        {
            // Arrange. 

            // Act. 
            Calculator calculator = new Calculator();
            calculator.PressDisplay(value);
            var actual = calculator.Display;

            // Assert. 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Function")]
        public void PressPlus()
        {
            PressPlusNegativeItemAndZeroItem();
        }

        [TestMethod]
        [TestCategory("Function")]
        public void PressMinus() { }

        [TestMethod]
        [TestCategory("Function")]
        public void PressMultiply() { }

        [TestMethod]
        [TestCategory("Function")]
        public void PressDivide() { }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressPlusNegativeItemAndZeroItem()
        {
            // Arrange.
            var value1 = -2.9;
            var value2 = 0;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressPlus();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = -2.9;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void NoInputData()
        {
            // Arrange.

            // Act.
            var calculator = new Calculator();
            var actual = calculator.Display;
            // Assert.
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("RangePermissibleValue")]
        [ExpectedException(typeof(OutOfRangeException))]
        public void PressPlusMinimumDoubleAndSomeItems()
        {
            // Arrange. 
            var value1 = double.MinValue;
            var value2 = int.MinValue;
            // Act. 
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressPlus();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            // Assert. 
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("RangePermissibleValue")]
        [ExpectedException(typeof(OutOfRangeException))]
        public void PressPlusMaximumDoubleAndSomeItems()
        {
            // Arrange. 
            var value1 = double.MaxValue;
            var value2 = short.MaxValue;
            // Act. 
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressPlus();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            // Assert. 
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("RangePermissibleValue")]
        [ExpectedException(typeof(DivideByZeroException))]
        public void PressDivideByZero()
        {
            // Arrange. 
            var value1 = 228;
            var value2 = 0;
            // Act. 
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressDivide();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            // Assert. 
            Assert.Fail();
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
