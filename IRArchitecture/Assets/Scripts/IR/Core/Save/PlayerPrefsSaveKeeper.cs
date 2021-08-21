using UnityEngine;

namespace IRCore.Save
{
    class PlayerPrefsSaveKeeper : ISaveKeeper
    {
        public bool Exist(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
        public string Load(string key)
        {
            return PlayerPrefs.GetString(key);
        }
        public void Save(string key, string content)
        {
            PlayerPrefs.SetString(key, content);
        }
    }
}