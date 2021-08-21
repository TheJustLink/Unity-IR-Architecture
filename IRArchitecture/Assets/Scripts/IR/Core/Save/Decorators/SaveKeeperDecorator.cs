namespace IRCore.Save.Decorators
{
    abstract class SaveKeeperDecorator : ISaveKeeper
    {
        private readonly ISaveKeeper _saveKeeper;

        public SaveKeeperDecorator(ISaveKeeper saveKeeper)
        {
            _saveKeeper = saveKeeper;
        }

        public bool Exist(string key)
        {
            return _saveKeeper.Exist(key);
        }
        public virtual string Load(string key)
        {
            return _saveKeeper.Load(key);
            
        }
        public virtual void Save(string key, string content)
        {
            _saveKeeper.Save(key, content);
        }
    }
}