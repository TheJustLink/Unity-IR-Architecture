#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

using IRCore.Tables;
using IRCore.Save;

namespace IRCore
{
    static class Game
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
            Debug.Log("[Game saved]");
            _repositories.Save();
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