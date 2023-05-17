using System;
using System.Collections.Generic;

namespace BTAS.BlazorApp.Services.Interface
{
    public delegate void TChangeDelegate(object sender, TChangeEventArgs args);

    public class TChangeEventArgs : EventArgs
    {
        public T NewValue { get; }
        public T OldValue { get; }

        public TChangeEventArgs(T newValue, T oldValue)
        {
            this.NewValue = newValue;
            this.OldValue = oldValue;
        }
    }

    public interface ITableChangeBroadcastService<T> : IDisposable where T : class
    {
        event TChangeDelegate OnTChanged;
        IList<T> GetCurrentValues();
    }
}
