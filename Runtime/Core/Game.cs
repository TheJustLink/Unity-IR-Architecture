#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

using IR.Tables;
using IR.Save;

namespace IR
{
    public static class Game
    {
        public static readonly SaveSettings SaveSettings = new SaveSettings();

        private static readonly InteractorsTable _interactors = new InteractorsTable();
        private static readonly RepositoriesTable _repositories = new RepositoriesTable(SaveSettings);

        public static T GetInteractor<T>() where T : IInteractor, new()
        {
            return _interactors.Get<T>();
        }
        public static T AddRepository<T>() where T : IRepository, new()
        {
            return _repositories.Get<T>();
        }

        public static void SaveGame()
        {
            if (UnityApplication.CanLogging)
                Debug.Log("[Game saved]");

            _repositories.Save();
        }
        public static void ClearSave()
        {
            Debug.Log("[Save cleared]");

            SaveSettings.SaveKeeper.Clear();

            _repositories.Clear();
            _interactors.Clear();
        }

        [RuntimeInitializeOnLoadMethod]
        private static void RuntimeInitialization()
        {
            UnityApplication.Paused += OnPaused;
            UnityApplication.Quited += OnPaused;
            UnityApplication.CreateApplicationObject();
        }
        private static void OnPaused() => SaveGame();

#if UNITY_EDITOR
        [MenuItem("Tools/DevLink/Clear save")]
        private static void ClearSaveInternal()
        {
            ClearSave();

            if (Application.isPlaying)
                EditorApplication.ExitPlaymode();
            else ReloadScripts();
        }
        private static void ReloadScripts()
        {
#if UNITY_2019_3_OR_NEWER
            EditorUtility.RequestScriptReload();
#else
            Debug.LogWarning("You should reload editor domain after delete saves (enter playmode or close editor)");
#endif
        }

        [InitializeOnLoadMethod]
        private static void OnEnterPlayMode()
        {
            EditorApplication.playModeStateChanged += PlayModeStateChanged;
            EditorApplication.quitting += SaveGame;
        }
        private static void PlayModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
                SaveGame();
        }
#endif
    }
}