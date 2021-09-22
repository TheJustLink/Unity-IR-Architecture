namespace IR
{
    public interface IInteractor { }
    public interface IInteractor<T> : IInteractor where T : IRepository { }
}