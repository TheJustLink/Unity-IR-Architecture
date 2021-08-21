namespace IRCore.Save
{
    interface ISaveKeeper
    {
        bool Exist(string key);
        string Load(string key);
        void Save(string key, string content);
    }
}