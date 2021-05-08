using UnityEngine;
using IRArchitecture;

public class MoneyRepository : IRepository
{
    public int Value { get; set; }
    private const string MoneyKey = "Money";

    public void Initialize()
    {
        Value = PlayerPrefs.GetInt(MoneyKey, 0);
    }
    public void Save()
    {
        PlayerPrefs.SetInt(MoneyKey, Value);
    }
}