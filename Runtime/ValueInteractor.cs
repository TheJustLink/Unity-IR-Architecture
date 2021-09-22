using System;

namespace IR
{
    public class ValueInteractor<R, V> : Interactor<R> where R : ValueRepository<V>, new()
    {
        public event Action<V> Changed;

        public V Value
        {
            get => Repository.Value;
            set
            {
                if (Repository.Value.Equals(value))
                    return;

                Repository.Value = value;
                Changed?.Invoke(value);
            }
        }
    }
}