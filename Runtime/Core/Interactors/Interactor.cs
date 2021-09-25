namespace IR
{
    public abstract class Interactor<R> : IInteractor<R> where R : IRepository, new()
    {
        protected R Repository
            => _repository ??= Game.AddRepository<R>();
        private R _repository;
    }
}