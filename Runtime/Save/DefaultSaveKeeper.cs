﻿using IR.Save.Decorators;

namespace IR.Save
{
    public class DefaultSaveKeeper : ISaveKeeper
    {
        private readonly ISaveKeeper _saveKeeper;

        public DefaultSaveKeeper()
        {
            _saveKeeper = new PlayerPrefsSaveKeeper();
            _saveKeeper = new Base64SaveKeeperDecorator(_saveKeeper);
        }

        public bool Exist(string key)
        {
            return _saveKeeper.Exist(key);
        }

        public void Clear()
        {
            _saveKeeper.Clear();
        }
        public void Remove(string key)
        {
            _saveKeeper.Remove(key);
        }

        public string Load(string key)
        {
            return _saveKeeper.Load(key);
        }
        public void Save(string key, string content)
        {
            _saveKeeper.Save(key, content);
        }
    }
}