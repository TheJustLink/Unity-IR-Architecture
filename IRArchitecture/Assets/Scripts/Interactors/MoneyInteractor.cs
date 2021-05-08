using System;
using IRArchitecture;

public class MoneyInteractor : IInteractor
{
    public int Value
    {
        get => _money.Value;
        set
        {
            _money.Value = value;
            Changed?.Invoke(value);
        }
    }
    public event Action<int> Changed;

    private MoneyRepository _money;
    public void Initialize()
    {
        _money = Game.GetRepository<MoneyRepository>();
    }

    public bool CanPay(int price) => Value >= price;
}