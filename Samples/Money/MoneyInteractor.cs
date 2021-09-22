using IR;

class MoneyInteractor : ValueInteractor<MoneyRepository, int>
{
    public bool CanPay(int price) => Value >= price;
}