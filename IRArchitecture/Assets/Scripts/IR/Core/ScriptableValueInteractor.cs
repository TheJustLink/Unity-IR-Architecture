using UnityEngine;

namespace IRCore
{
    class ScriptableValueInteractor<I, R, V> : ScriptableObject where R : ValueRepository<V>, new() where I : ValueInteractor<V, R>, new()
    {
        public I Interactor
            => _interactor ??= Game.GetInteractor<I>();
        private I _interactor;

        public V Value
        {
            get => Interactor.Value;
            set => Interactor.Value = value;
        }

        [SerializeProperty(nameof(Value))]
        [SerializeField] private V _value;
    }
}