namespace IRCore.Json
{
    interface IJsonConverter
    {
        string Convert(object obj);
        T Convert<T>(string json);
    }
}