using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public class ObservableValue<T>
    {
        public class ChangingEventArgs : EventArgs
        {
            public T OldValue { get; }
            public T NewValue { get; }
            public bool Cancel { get; set; }

            public ChangingEventArgs(T oldValue, T newValue)
            {
                OldValue = oldValue;
                NewValue = newValue;
                Cancel = false;
            }
        }

        public class ChangedEventArgs : EventArgs
        {
            public T Value { get; }

            public ChangedEventArgs(T value)
            {
                Value = value;
            }
        }

        public class NoChangingEventArgs : EventArgs
        {
            public T Value { get; }

            public NoChangingEventArgs(T value)
            {
                Value = value;
            }
        }

        public event EventHandler<ChangingEventArgs> Changing;
        public event EventHandler<ChangedEventArgs> Changed;
        public event EventHandler<NoChangingEventArgs> NoChanging;

        protected T _value;

        public T Value
        {
            get => _value;
            set
            {
                
                if (_value.Equals(value))
                {
                    OnNoChanging(new NoChangingEventArgs(_value));
                    return;
                }
                ChangingEventArgs e = new ChangingEventArgs(_value, value);
                OnChanging(e);
                if (e.Cancel)
                {
                    return;
                }
                _value = value;
                OnChanged(new ChangedEventArgs(_value));
            }
        }

        public ObservableValue() { }

        public ObservableValue(T value)
        {
            _value = value;
        }

        protected virtual void OnChanging(ChangingEventArgs e)
        {
            EventHandler<ChangingEventArgs> handler = Changing;
            handler?.Invoke(this, e);
        }

        protected virtual void OnChanged(ChangedEventArgs e)
        {
            EventHandler<ChangedEventArgs> handler = Changed;
            handler?.Invoke(this, e);
        }

        protected virtual void OnNoChanging(NoChangingEventArgs e)
        {
            EventHandler<NoChangingEventArgs> handler = NoChanging;
            handler?.Invoke(this, e);
        }
    }
}
