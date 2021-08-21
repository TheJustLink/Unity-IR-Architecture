using IRCore;

class MoneyInteractor : ValueInteractor<int, MoneyRepository>
{
    public bool CanPay(int price) => Value >= price;
}