using UnityEngine;
using UnityEngine.UI;

using IRCore;

[RequireComponent(typeof(Text))]
public sealed class MoneyUIPresenter : MonoBehaviour
{
    [SerializeField] private string _format = "Money: {0}";

    private Text _text;
    private MoneyInteractor _money;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _money = Game.GetInteractor<MoneyInteractor>();
    }

    private void OnEnable()
    {
        _money.Changed += OnMoneyChanged;
        OnMoneyChanged(_money.Value);
    }
    private void OnDisable()
    {
        _money.Changed -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int value)
    {
        SetText(value.ToString());
    }
    private void SetText(string text)
    {
        _text.text = string.Format(_format, text);
    }
}