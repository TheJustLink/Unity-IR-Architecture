namespace IRArchitecture
{
    public class RepositoriesTable : InitializableTable<IRepository>, ISaveable
    {
        public void Save()
        {
            foreach (var repository in this)
                repository.Save();
        }
    }
}
