using UnityEngine;

using IR;

/// <summary>
/// You can access to your interactor in ScriptableObject
/// Yeah, this works fine in Editor
/// Saves works too
/// </summary>
[CreateAssetMenu(menuName = "Game/Interactors/Money")]
class ScriptableMoneyInteractor : ScriptableValueInteractor<MoneyInteractor, MoneyRepository, int> { }