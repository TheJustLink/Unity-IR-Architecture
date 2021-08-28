namespace IRCore
{
    interface IInteractor { }
    interface IInteractor<T> : IInteractor where T : IRepository { }
}