using UnityEngine;
using System.Collections.Generic;
public abstract class DataPlayer 
{
    private string _dataName;
    private int _countMoney = 10;
    private int _countPower;
    private int _countHealth;

    private List<IEnemy> _enemyList = new List<IEnemy>();

    public string DataName => _dataName;
    public int CountMoney
    {
        get => _countMoney;
        set
        {
            if(_countMoney != value)
            {
                _countMoney = value;
                Notify(DataType.Money);
            }
        }
    }
    public int CountPower
    {
        get => _countPower;
        set
        {
            if (_countPower != value)
            {
                _countPower = value;
                Notify(DataType.Power);
            }
        }
    }
    public int CountHealth
    {
        get => _countHealth;
        set
        {
            if (_countHealth != value)
            {
                _countHealth = value;
                Notify(DataType.Health);
            }
        }
    }

    protected DataPlayer(string dataName)
    {
        _dataName = dataName;
    }

    public void AddEnemy(IEnemy enemy)
    {
        _enemyList.Add(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        _enemyList.Remove(enemy);
    }

    public void Notify(DataType dataType)
    {
        foreach(var enemy in _enemyList)
        {
            enemy.Update(this, dataType);
        }
    }
}

