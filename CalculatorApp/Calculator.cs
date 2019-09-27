using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public class Calculator
    {
        double currentValue = 0;
        string operation = "=";
        public double Display { get; set; }
        public void PressEnter()
        {
            Calculate();
            operation = "=";
        }
        public void PressDisplay(double value)
        {
            currentValue = value;
        }
        public void PressPlus()
        {

        }
        public void PressMinus()
        {

        }
        public void PressMultiply()
        {

        }
        public void PressDivide()
        {

        }
        void Calculate()
        {

        }
    }
}
