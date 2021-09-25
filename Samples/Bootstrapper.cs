/*
#if UNITY_EDITOR
using UnityEditor;
#endif

using IR;
using IR.Save;
using IR.Save.Decorators;

static class Bootstrapper
{
    private const string SavePassword = "Password";

    private static void InitializeSaveSettings()
    {
        // You can realize other db savekeepers (files, sqlite, etc)
        ISaveKeeper saveKeeper = new PlayerPrefsSaveKeeper();
        saveKeeper = new RijndaelEncryptionSaveKeeperDecorator(saveKeeper, SavePassword);

        Game.SaveSettings.SaveKeeper = saveKeeper;

        // You can make wrapper for newtonsoft powerfull json converter
        // instead of unity json
        // Game.SaveSettings.JsonConverter = new NewtonsoftJsonConverter();
    }

    [RuntimeInitializeOnLoadMethod]
    private static void OnInitializeRuntime()
    {
        InitializeSaveSettings();
    }
#if UNITY_EDITOR
    [InitializeOnLoadMethod]
    private static void OnInitializeEditor()
    {
        InitializeSaveSettings();
    }
#endif
}
*/