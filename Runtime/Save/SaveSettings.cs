using IR.Json;

namespace IR.Save
{
    public class SaveSettings
    {
        public ISaveKeeper SaveKeeper { get; set; }
        public IJsonConverter JsonConverter { get; set; }

        public SaveSettings()
        {
            SaveKeeper = new DefaultSaveKeeper();
            JsonConverter = new UnityJsonConverter();
        }
        public SaveSettings(ISaveKeeper saveKeeper, IJsonConverter jsonConverter)
        {
            SaveKeeper = saveKeeper;
            JsonConverter = jsonConverter;
        }
    }
}