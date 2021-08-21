using System;

namespace IRCore
{
    class ValueInteractor<V, R> : IInteractor where R : ValueRepository<V>, new()
    {
        public event Action<V> Changed;

        public V Value
        {
            get => _repository.Value;
            set
            {
                _repository.Value = value;
                Changed?.Invoke(value);
            }
        }

        private R _repository;

        public void Initialize()
        {
            _repository = Game.GetRepository<R>();
        }
    }
}