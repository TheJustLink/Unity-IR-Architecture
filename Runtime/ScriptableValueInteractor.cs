using UnityEngine;

namespace IR
{
    public class ScriptableValueInteractor<I, R, V> : ScriptableObject where R : ValueRepository<V>, new() where I : ValueInteractor<R, V>, new()
    {
        public I Interactor
            => _interactor ??= Game.GetInteractor<I>();
        private I _interactor;

        /// <summary>
        /// Use OdinInspector to draw properties in inspector
        /// or custom drawer (current SerializeProperty)
        /// </summary>
        public V Value
        {
            get => Interactor.Value;
            set => Interactor.Value = value;
        }

        [SerializeProperty(nameof(Value))]
        [SerializeField] private V _value;
    }
}