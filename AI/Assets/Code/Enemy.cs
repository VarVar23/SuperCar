using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IEnemy
{
    private const int KCoins = 5;
    private const float KPower = 1.5f;
    private const int MaxHealthPlayer = 20;

    private string _name;
    private int _countMoney;
    private int _countHealth;
    private int _countPower;

    public int Power => GeneratePower();

    public Enemy(string name)
    {
        _name = name;
    }

    public int GeneratePower()
    {
        int result = (_countPower - _countHealth + _countMoney) / 2;
        return result;
    }

    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        if (dataType == DataType.Money) _countMoney = dataPlayer.CountMoney;
        if (dataType == DataType.Power) _countPower = dataPlayer.CountPower;
        if (dataType == DataType.Health) _countHealth = dataPlayer.CountHealth; 
    }
}
