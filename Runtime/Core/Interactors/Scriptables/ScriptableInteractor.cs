using UnityEngine;

namespace IR
{
    public abstract class ScriptableInteractor<I> : ScriptableObject, IScriptableInteractor<I>
        where I : IInteractor, new()
    {
        public I Interactor
            => _interactor ??= Game.GetInteractor<I>();
        private I _interactor;
    }
}