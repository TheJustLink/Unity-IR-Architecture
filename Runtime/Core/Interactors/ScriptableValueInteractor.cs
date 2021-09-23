using System;

using UnityEngine;

namespace IR
{
    public abstract class ScriptableValueInteractor<V> : ScriptableObject, IValueInteractor<V>
    {
        public abstract event Action<V> Changed;

        public abstract V Value { get; set; }
    }
    public class ScriptableValueInteractor<I, R, V> : ScriptableValueInteractor<V> where R : ValueRepository<V>, new() where I : ValueInteractor<R, V>, new()
    {
        public override event Action<V> Changed
        {
            add => Interactor.Changed += value;
            remove => Interactor.Changed -= value;
        }

        public override V Value
        {
            get => Interactor.Value;
            set => Interactor.Value = value;
        }

        public I Interactor
            => _interactor ??= Game.GetInteractor<I>();
        private I _interactor;

#if UNITY_EDITOR
        /// <summary>
        /// Use OdinInspector to draw properties in inspector
        /// or custom drawer (current SerializeProperty)
        /// </summary>
        [SerializeProperty(nameof(Value))]
        [SerializeField] private V _value;
#endif
    }
}