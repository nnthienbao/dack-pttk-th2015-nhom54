using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PropertyChangingCancelEventArgs : PropertyChangingEventArgs
    {
        public bool Cancel { get; set; }
        public PropertyChangingCancelEventArgs(string propertyName) : base(propertyName)
        {

        }
    }

    public class PropertyChangingCancelEventArgs<T> : PropertyChangingCancelEventArgs
    {
        public T OriginalValue { get; private set; }

        public T NewValue { get; private set; }

        public PropertyChangingCancelEventArgs(string propertyName, T originalValue, T newValue)
            : base(propertyName)
        {
            this.OriginalValue = originalValue;
            this.NewValue = newValue;
        }
    }
}
