using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public enum Operation : byte
    {
        Null,
        Display,
        Press,
        Enter
    }

    public class Calculator
    {
        private readonly ObservableValue<double> _currentValue;
        private string _operation;
        private bool _isNew;
        private double _newValue;

        public double CurrentValue
        {
            get => _currentValue.Value;
            set
            {
                _lastOperation.Value = Operation.Display;
                _currentValue.Value = value;
            }
        }

        private readonly ObservableValue<Operation> _lastOperation;

        public Calculator()
        {
            _lastOperation = new ObservableValue<Operation>(Operation.Null);
            _lastOperation.Changing += lastOperation_Changing;
            _currentValue = new ObservableValue<double>(0);
            _currentValue.Changed += currentValue_Changed;
            _operation = "=";
            _isNew = false;
            CurrentValue = 0;
            _newValue = 0;
        }

        private void lastOperation_Changing(object sender, ObservableValue<Operation>.ChangingEventArgs e)
        {
            if (e.OldValue.Equals(e.NewValue))
            {
                throw new ArrangeInputDataException();
            }
        }

        private void currentValue_Changed(object sender, ObservableValue<double>.ChangedEventArgs e)
        {
            if (double.IsInfinity((double)e.Value))
            {
                throw new OutOfRangeException();
            }
        }

        public void PressEnter()
        {
            _lastOperation.Value = Operation.Enter;
            _operation = "=";
            Calculate();
        }

        public void PressDisplay(double value)
        {
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
            _lastOperation.Value = Operation.Press;
            _operation = "+";
        }

        public void PressMinus()
        {
            _lastOperation.Value = Operation.Press;
            _operation = "-";
        }

        public void PressMultiply()
        {
            _lastOperation.Value = Operation.Press;
            _operation = "*";
        }

        public void PressDivide()
        {
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

                default:
                    break;
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
    }
}
