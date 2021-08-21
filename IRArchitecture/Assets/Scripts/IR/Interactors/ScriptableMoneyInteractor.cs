using UnityEngine;

using IRCore;

[CreateAssetMenu(menuName = "Game/Interactors/Money")]
class ScriptableMoneyInteractor : ScriptableValueInteractor<MoneyInteractor, MoneyRepository, int> { }