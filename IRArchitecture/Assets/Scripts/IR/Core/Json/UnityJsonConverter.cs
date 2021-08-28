using UnityEngine;

namespace IRCore.Json
{
    class UnityJsonConverter : IJsonConverter
    {
        public string Convert(object obj)
        {
            return JsonUtility.ToJson(obj);
        }
        public T Convert<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}