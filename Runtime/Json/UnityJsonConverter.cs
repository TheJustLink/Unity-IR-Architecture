using UnityEngine;

namespace IR.Json
{
    public class UnityJsonConverter : IJsonConverter
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