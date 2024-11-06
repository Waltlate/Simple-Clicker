using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyData", menuName = "MoneyData")]
public class MoneyData : ScriptableObject
{
    public event Action onChangeMoney = delegate { };

    [SerializeField, Min(0)] protected double money = 0;

    public double Money => money;

    /// <summary>
    /// add money
    /// </summary>
    /// <param name="count"></param>
    public void AddMoney(double count)
    {
        money += count;
        onChangeMoney.Invoke();
    }

    /// <summary>
    /// decrease money
    /// </summary>
    /// <param name="count"></param>
    public void DecreaseMoney(double count)
    {
        money -= count;
        onChangeMoney.Invoke();
    }
}
