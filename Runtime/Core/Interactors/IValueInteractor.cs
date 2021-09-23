using System;

namespace IR
{
    public interface IValueInteractor<V> : IInteractor
    {
        public event Action<V> Changed;

        public abstract V Value { get; set; }
    }
}