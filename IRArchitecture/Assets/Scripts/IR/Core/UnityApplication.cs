using System;
using UnityEngine;

namespace IRCore
{
    class UnityApplication : MonoBehaviour
    {
        public static UnityApplication CreateApplicationObject()
        {
            var application = FindObjectOfType<UnityApplication>(true);
            if (application != null)
                return application;

            var gameObject = new GameObject($"[{nameof(UnityApplication)}]");
            gameObject.hideFlags = HideFlags.None;
            DontDestroyOnLoad(gameObject);

            return gameObject.AddComponent<UnityApplication>();
        }

        public static bool CanLogging = !Application.isEditor;
        public static event Action Started;
        public static event Action Paused;
        public static event Action Unpaused;
        public static event Action Focused;
        public static event Action Unfocused;
        public static event Action Quited;

        private void Start()
        {
            Log("[Game started " + Application.productName + "]");
            Started?.Invoke();
        }
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                Log("[Game paused]");
                Paused?.Invoke();
            }
            else
            {
                Log("[Game unpaused]");
                Unpaused?.Invoke();
            }
        }
        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                Log("[Game focused]");
                Focused?.Invoke();
            }
            else
            {
                Log("[Game unfocused])");
                Unfocused?.Invoke();
            }
        }
        private void OnApplicationQuit()
        {
            Log("[Game closed]");
            Quited?.Invoke();
        }

        private void Log(string message)
        {
            if (CanLogging)
                Debug.Log(message);
        }
    }
}