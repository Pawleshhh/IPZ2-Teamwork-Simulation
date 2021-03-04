using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation
{
    public class DataEventArgs<T> : EventArgs
    {

        public T Value { get; }

        public DataEventArgs(T value)
        {
            Value = value;
        }

    }
}
