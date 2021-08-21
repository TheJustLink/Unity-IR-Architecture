namespace IRCore.Tables
{
    class InitializableTable<T> : TypeTable<T> where T : IInitializable
    {
        protected override U CreateValue<U>()
        {
            var value = base.CreateValue<U>();
            value.Initialize();

            return value;
        }
    }
}