namespace IR
{
    public interface IScriptableInteractor<I> where I : IInteractor
    {
        I Interactor { get; }       
    }
}