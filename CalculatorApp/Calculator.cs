using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public enum Operation : byte
    {
        Null,
        Display,
        Press
    }

    public class Calculator
    {
        private readonly ObservableValue<double> _currentValue;
        private string _operation;
        private bool _isNew;
        private double _newValue;
        private readonly ObservableValue<Operation> _lastOperation;

        public double CurrentValue
        {
            get => _currentValue.Value;
            set => _currentValue.Value = value;
        }


        public Calculator()
        {
            _lastOperation = new ObservableValue<Operation>(Operation.Null);
            _lastOperation.NoChanging += lastOperation_NoChanging;
            _currentValue = new ObservableValue<double>(0);
            _currentValue.Changed += currentValue_Changed;
            _operation = "=";
            _isNew = false;
            CurrentValue = 0;
            _newValue = 0;
        }

        private void lastOperation_NoChanging(object sender, ObservableValue<Operation>.NoChangingEventArgs e)
        {
            throw new ArrangeInputDataException();
        }

        private void currentValue_Changed(object sender, ObservableValue<double>.ChangedEventArgs e)
        {
            if (double.IsInfinity(e.Value))
            {
                throw new OutOfRangeException();
            }
        }

        public void PressEnter()
        {
            _lastOperation.Value = Operation.Press;
            _operation = "=";
            Calculate();
        }

        public void PressDisplay(double value)
        {
            _lastOperation.Value = Operation.Display;
            _newValue = value;
            if (_isNew)
            {
                Calculate();
            }
            else
            {
                CurrentValue = _newValue;
            }
            _isNew = true;
        }

        public void PressPlus()
        {
            TestInputBeforeOperation();
            _lastOperation.Value = Operation.Press;
            _operation = "+";
        }

        public void PressMinus()
        {
            TestInputBeforeOperation();
            _lastOperation.Value = Operation.Press;
            _operation = "-";
        }

        public void PressMultiply()
        {
            TestInputBeforeOperation();
            _lastOperation.Value = Operation.Press;
            _operation = "*";
        }

        public void PressDivide()
        {
            TestInputBeforeOperation();
            _lastOperation.Value = Operation.Press;
            _operation = "/";
        }

        private void Calculate()
        {
            switch (_operation)
            {
                case "+":
                    Plus();
                    break;

                case "-":
                    Minus();
                    break;

                case "*":
                    Multiply();
                    break;

                case "/":
                    Divide();
                    break;

                default: break;
            }
        }

        private void Plus()
        {
            CurrentValue += _newValue;
        }

        private void Minus()
        {
            CurrentValue -= _newValue;
        }

        private void Multiply()
        {
            CurrentValue *= _newValue;
        }

        private void Divide()
        {
            if (_newValue.Equals(0))
            {
                throw new DivideByZeroException();
            }
            CurrentValue /= _newValue;
        }

        private void TestInputBeforeOperation()
        {
            if (_isNew == false)
            {
                throw new ArrangeInputDataException();
            }
        }
    }
}
