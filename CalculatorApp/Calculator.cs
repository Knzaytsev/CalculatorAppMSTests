using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public class Calculator
    {
        double currentValue;
        string operation;
        bool isNew;
        public double Display { get; set; }

        public Calculator()
        {
            currentValue = 0;
            operation = "=";
            isNew = false;
            Display = 0;
        }
        public void PressEnter()
        {
            operation = "=";
            Calculate();
        }
        public void PressDisplay(double value)
        {
            if (isNew)
            {
                Display = value;
                Calculate();
            }
            else
            {
                currentValue = value;
            }
            isNew = true;
        }
        public void PressPlus()
        {
            operation = "+";
        }
        public void PressMinus()
        {
            operation = "-";
        }
        public void PressMultiply()
        {
            operation = "*";
        }
        public void PressDivide()
        {
            operation = "/";
        }
        private void Calculate()
        {
            switch (operation)
            {
                case "+":
                    _plus();
                    break;

                case "-":
                    _minus();
                    break;

                case "*":
                    _multiply();
                    break;

                case "/":
                    _divide();
                    break;

                case "=":
                    _enter();
                    break;

                default:
                    break;
            }
        }

        private void _plus()
        {
            currentValue += Display;
        }

        private void _minus()
        {
            currentValue -= Display;
        }

        private void _multiply()
        {
            currentValue *= Display;
        }

        private void _divide()
        {
            currentValue /= Display;
        }

        private void _enter()
        {
            Display = currentValue;
        }
    }
}
