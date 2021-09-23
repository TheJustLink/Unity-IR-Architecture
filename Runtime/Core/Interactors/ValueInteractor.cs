using System;

namespace IR
{
    public class ValueInteractor<R, V> : Interactor<R>, IValueInteractor<V> where R : ValueRepository<V>, new()
    {
        public virtual event Action<V> Changed;
        public virtual V Value
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