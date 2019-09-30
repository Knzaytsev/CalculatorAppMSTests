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
            PressPlusTwoItems();
        }

        [TestMethod]
        [TestCategory("Function")]
        public void PressMinus()
        {
            PressMinusMultiplyPlusDivideFiveItems();
        }

        [TestMethod]
        [TestCategory("Function")]
        public void PressMultiply()
        {
            PressMultiplyTwoItems();
        }

        [TestMethod]
        [TestCategory("Function")]
        public void PressDivide()
        {
            PressMinusMultiplyPlusDivideFiveItems();
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressPlusTwoItems()
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
        public void PressMultiplyTwoItems()
        {
            // Arrange.
            var value1 = 98.5;
            var value2 = -9853;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressMultiply();
            calculator.PressDisplay(value2);
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = -970520.5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("InputData")]
        public void PressMinusMultiplyPlusDivideFiveItems()
        {
            // Arrange.
            var value1 = 128;
            var value2 = 6;
            var value3 = 2;
            var value4 = 22;
            var value5 = 2;
            // Act.
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressMinus();
            calculator.PressDisplay(value2);
            calculator.PressMultiply();
            calculator.PressDisplay(value3);
            calculator.PressPlus();
            calculator.PressDisplay(value4);
            calculator.PressDivide();
            calculator.PressDisplay(value5);
            calculator.PressEnter();
            calculator.PressEnter();
            var actual = calculator.Display;
            // Assert.
            var expected = 133;
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
        [TestCategory("OutputData")]
        public void OutPositiveValue()
        {
            PressMinusMultiplyPlusDivideFiveItems();
        }

        [TestMethod]
        [TestCategory("OutputData")]
        public void OutNegativeValue()
        {
            PressMultiplyTwoItems();
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
        [TestCategory("RangePermissibleValue")]
        [ExpectedException(typeof(OutOfRangeException))]
        public void PressPlusMinimumDoubleAndMinimumIntItem()
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
        public void PressPlusMaximumDoubleAndMaximumShortItem()
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
        [TestCategory("LengthInputData")]
        public void ZeroItems()
        {
            NoInputData();
        }

        [TestMethod]
        [TestCategory("LengthInputData")]
        public void OneItem()
        {
            // Arrange. 
            var value = 9;

            // Act. 
            Calculator calculator = new Calculator();
            calculator.PressDisplay(value);
            var actual = calculator.Display;

            // Assert. 
            var expected = 9;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("LengthInputData")]
        public void PressPlusTenItem()
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
        [TestCategory("ArrangeInputData")]
        [ExpectedException(typeof(ArrangeInputDataException))]
        public void ItemByItem()
        {
            // Arrange.
            var value1 = 8;
            var value2 = 1.89;
            var value3 = -23;
            var value4 = 0;

            // Act. 
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressDisplay(value2);
            calculator.PressDisplay(value3);
            calculator.PressPlus();
            calculator.PressDisplay(value4);
            calculator.PressEnter();

            // Assert. 
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("ArrangeInputData")]
        [ExpectedException(typeof(ArrangeInputDataException))]
        public void OperationByOperation()
        {
            // Arrange.
            var value1 = 2;
            var value2 = 98;
            var value3 = 2;

            // Act. 
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressPlus();
            calculator.PressMultiply();
            calculator.PressDisplay(value2);
            calculator.PressDivide();
            calculator.PressDisplay(value3);
            calculator.PressEnter();

            // Assert. 
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("ArrangeInputData")]
        [ExpectedException(typeof(ArrangeInputDataException))]
        public void OperationFirst()
        {
            // Arrange.
            var value1 = 12;
            var value2 = 8.9;
            var value3 = -1;

            // Act. 
            var calculator = new Calculator();
            calculator.PressDivide();
            calculator.PressDisplay(value1);
            calculator.PressPlus();
            calculator.PressDisplay(value2);
            calculator.PressMinus();
            calculator.PressDisplay(value3);
            calculator.PressEnter();

            // Assert. 
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("ArrangeInputData")]
        [ExpectedException(typeof(ArrangeInputDataException))]
        public void OperationLast()
        {
            // Arrange.
            var value1 = 98;
            var value2 = 21;
            var value3 = 98;
            var value4 = 2;

            // Act. 
            var calculator = new Calculator();
            calculator.PressDisplay(value1);
            calculator.PressPlus();
            calculator.PressDisplay(value2);
            calculator.PressMinus();
            calculator.PressDisplay(value3);
            calculator.PressDivide();
            calculator.PressDisplay(value4);
            calculator.PressMultiply();
            calculator.PressEnter();

            // Assert. 
            Assert.Fail();
        }
    }
}
