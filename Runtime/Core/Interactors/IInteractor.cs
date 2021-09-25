namespace IR
{
    public interface IInteractor { }
    public interface IInteractor<R> : IInteractor where R : IRepository { }
}