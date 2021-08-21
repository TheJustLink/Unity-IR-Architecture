using IRCore.Save;

namespace IRCore.Tables
{
    sealed class RepositoriesTable : SaveableTable<IRepository>
    {
        private RepositoriesTable() { }
        public RepositoriesTable(ISaveKeeper saveKeeper)
            : base(saveKeeper) { }
    }
}