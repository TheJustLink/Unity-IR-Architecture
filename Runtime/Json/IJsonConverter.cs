namespace IR.Json
{
    public interface IJsonConverter
    {
        string Convert(object obj);
        T Convert<T>(string json);
    }
}