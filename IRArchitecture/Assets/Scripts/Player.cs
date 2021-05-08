using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int _addMoneyCount = 10;
    [SerializeField] private int _subMoneyCount = 5;

    private MoneyInteractor _money;
    private void Start()
    {
        _money = Game.GetInteractor<MoneyInteractor>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _money.Value += _addMoneyCount;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (_money.CanPay(_subMoneyCount))
                _money.Value -= _subMoneyCount;
        }
    }
}