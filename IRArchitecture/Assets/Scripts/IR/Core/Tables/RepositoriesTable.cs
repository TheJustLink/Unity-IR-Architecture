using System;

using IRCore.Save;

namespace IRCore.Tables
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

        protected override U CreateValue<U>()
        {
            var key = GetKey(typeof(U));

            return _saveSettings.SaveKeeper.Exist(key)
                ? TryLoad<U>(key)
                : Create<U>();
        }

        
        private T TryLoad<T>(string key) where T : IRepository, new()
        {
            try
            {
                return Load<T>(key);
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogError($"Can't load {key}: {exception.Message} => {exception.StackTrace}");
            }

            return Create<T>();
        }
        private T Create<T>() where T : IRepository, new()
        {
            return new T();
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