namespace IRCore
{
    abstract class Interactor<T> : IInteractor<T> where T : IRepository, new()
    {
        protected T Repository;

        public Interactor()
        {
            Repository = Game.AddRepository<T>();
        }
    }
}