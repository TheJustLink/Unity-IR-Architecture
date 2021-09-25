using System;

using UnityEngine;

namespace IR
{
    public abstract class ScriptableValueInteractor<I, V> : ScriptableInteractor<I>, IScriptableValueInteractor<I, V>
        where I : IValueInteractor<V>, new()
    {
        public event Action<V> Changed
        {
            add => Interactor.Changed += value;
            remove => Interactor.Changed -= value;
        }
        public V Value
        {
            get => Interactor.Value;
            set => Interactor.Value = value;
        }

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