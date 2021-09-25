using IR.Save;

namespace IR
{
    public class ValueRepository<T> : IRepository, ISaveable
    {
        public T Value;
    }
}