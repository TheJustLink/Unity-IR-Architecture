namespace IR.Save
{
    public interface ISaveKeeper
    {
        bool Exist(string key);

        void Clear();
        void Remove(string key);

        string Load(string key);
        void Save(string key, string content);
    }
}