using UnityEngine;

using IRCore.Save;
using System;

namespace IRCore.Tables
{
    class SaveableTable<T> : TypeTable<T> where T : ISaveable
    {
        public ISaveKeeper SaveKeeper { get; set; }

        protected SaveableTable() { }
        public SaveableTable(ISaveKeeper saveKeeper)
        {
            SaveKeeper = saveKeeper;
        }

        public void Save()
        {
            foreach (var saveable in this)
                Save(saveable);
        }

        protected override U CreateValue<U>()
        {
            var key = GetKey<U>();

            return SaveKeeper.Exist(key)
                ? Load<U>(key)
                : base.CreateValue<U>();
        }
        
        private U Load<U>(string key)
        {
            var json = SaveKeeper.Load(key);
            var value = JsonUtility.FromJson<U>(json);

            return value;
        }
        private void Save(ISaveable saveable)
        {
            var json = JsonUtility.ToJson(saveable);
            var key = GetKey(saveable);

            SaveKeeper.Save(key, json);
        }

        private string GetKey<U>()
        {
            return GetKey(typeof(U));
        }
        private string GetKey(object obj)
        {
            return GetKey(obj.GetType());
        }
        private string GetKey(Type type)
        {
            return type.FullName;
        }
    }
}