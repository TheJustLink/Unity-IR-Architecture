using UnityEngine;
using IRArchitecture;

public static class Game
{
    private static InteractorsTable _interactors = new InteractorsTable();
    private static RepositoriesTable _repositories = new RepositoriesTable();

    public static T GetInteractor<T>() where T : IInteractor, new() => _interactors.Get<T>();
    public static T GetRepository<T>() where T : IRepository, new() => _repositories.Get<T>();

    public static void SaveGame()
    {
        Debug.Log("[Game saved]");
        _repositories.Save();
    }

    [RuntimeInitializeOnLoadMethod]
    private static void Initialization()
    {
        UnityApplication.Paused += OnPaused;
        UnityApplication.Quited += OnPaused;
        UnityApplication.CreateHandler();
    }
    private static void OnPaused() => SaveGame();
}