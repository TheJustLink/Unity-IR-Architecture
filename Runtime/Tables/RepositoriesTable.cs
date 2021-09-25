using System;

using IR.Save;

namespace IR.Tables
{
    sealed class RepositoriesTable : TypeTable<IRepository>
    {
        private readonly SaveSettings _saveSettings;

        private RepositoriesTable() { }
        public RepositoriesTable(SaveSettings saveSettings)
        {
            _saveSettings = saveSettings;
        }

        public void Save()
        {
            foreach (var repository in this)
            {
                if (repository is ISaveable saveable)
                    Save(saveable);
                else if (repository is ICustomSaveable customSaveable)
                    customSaveable.Save();
            }
        }

        protected override U CreateInternal<U>()
        {
            return TryLoad<U>();
        }
        
        private T TryLoad<T>() where T : IRepository, new()
        {
            var key = GetKey(typeof(T));
            var hasSave = _saveSettings.SaveKeeper.Exist(key);

            if (hasSave == false)
                return base.CreateInternal<T>();

            try
            {
                return Load<T>(key);
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogError($"Can't load {key}: {exception.Message} => {exception.StackTrace}");
            }

            return base.CreateInternal<T>();
        }
        private T Load<T>(string key) where T : IRepository
        {
            var json = _saveSettings.SaveKeeper.Load(key);
            var value = _saveSettings.JsonConverter.Convert<T>(json);

            return value;
        }
        private void Save(ISaveable saveable)
        {
            var json = _saveSettings.JsonConverter.Convert(saveable);
            var key = GetKey(saveable.GetType());

            _saveSettings.SaveKeeper.Save(key, json);
        }

        private string GetKey(Type type)
        {
            return type.FullName;
        }
    }
}