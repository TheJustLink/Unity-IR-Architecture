namespace IR
{
    public interface IScriptableValueInteractor<I, V> : IScriptableInteractor<I>, IValueInteractor<V>
        where I : IValueInteractor<V> { }
}