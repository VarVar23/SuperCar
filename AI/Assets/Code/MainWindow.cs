using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class MainWindow : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _moneyPlayer;
    [SerializeField] private TextMeshProUGUI _healthPlayer;
    [SerializeField] private TextMeshProUGUI _powerPlayer;
    [SerializeField] private TextMeshProUGUI _powerEnemy;

    [Header("Buttons")]
    [SerializeField] private Button _addMoney;
    [SerializeField] private Button _addHealth;
    [SerializeField] private Button _addPower;
    [SerializeField] private Button _minusMoney;
    [SerializeField] private Button _minusHealth;
    [SerializeField] private Button _minusPower;
    [SerializeField] private Button _fight;

    private int _countMoneyPlayer;
    private int _countHealthPlayer;
    private int _countPowerPlayer;

    private Health _health;
    private Power _power;
    private Money _money;
    private Enemy _enemy;

    private void Start()
    {
        Initialize();
        AddListener();
    }

    private void Initialize()
    {
        _health = new Health(nameof(Health));
        _power = new Power(nameof(Power));
        _money = new Money(nameof(Money));
        _enemy = new Enemy(nameof(Enemy));

        AddEnemy(_enemy);
    }

    private void AddListener()
    {
        _addMoney.onClick.AddListener(() => ChangeMoney(true));
        _minusMoney.onClick.AddListener(() => ChangeMoney(false));

        _addHealth.onClick.AddListener(() => ChangeHealth(true));
        _minusHealth.onClick.AddListener(() => ChangeHealth(false));

        _addPower.onClick.AddListener(() => ChangePower(true));
        _minusPower.onClick.AddListener(() => ChangePower(false));

        _fight.onClick.AddListener(Fight);
    }

    private void ChangeMoney(bool add)
    {
        _countMoneyPlayer += add ? 1 : -1;
        UpdateDataWindow(DataType.Money);
    }

    private void ChangeHealth(bool add)
    {
        _countHealthPlayer += add ? 1 : -1;
        UpdateDataWindow(DataType.Health);
    }

    private void ChangePower(bool add)
    {
        _countPowerPlayer += add ? 1 : -1;
        UpdateDataWindow(DataType.Power);
    }

    private void UpdateDataWindow(DataType dataType)
    {
        if(dataType == DataType.Money)
        {
            _moneyPlayer.text = $"Player Money: {_countMoneyPlayer.ToString()}";
            _money.CountMoney = _countMoneyPlayer;
        }

        if (dataType == DataType.Power)
        {
            _powerPlayer.text = $"Player Power: {_countPowerPlayer.ToString()}";
            _power.CountPower = _countPowerPlayer;
        }

        if (dataType == DataType.Health)
        {
            _healthPlayer.text = $"Player Health: {_countHealthPlayer.ToString()}";
            _health.CountHealth = _countHealthPlayer;
        }

        _powerEnemy.text = $"Enemy Power: {_enemy.Power}";
    }

    private void Fight()
    {
        if(_enemy.Power > _countPowerPlayer)
        {
            Debug.Log("You lose");
        }
        else
        {
            Debug.Log("You win");
        }
    }

    private void AddEnemy(IEnemy enemy)
    {
        _health.AddEnemy(enemy);
        _power.AddEnemy(enemy);
        _money.AddEnemy(enemy);
    }

    private void RemoveEnemy(IEnemy enemy)
    {
        _health.RemoveEnemy(enemy);
        _power.RemoveEnemy(enemy);
        _money.RemoveEnemy(enemy);
    }

    private void OnDestroy()
    {
        _addMoney.onClick.RemoveAllListeners();
        _addHealth.onClick.RemoveAllListeners();
        _addPower.onClick.RemoveAllListeners();
        _minusMoney.onClick.RemoveAllListeners();
        _minusHealth.onClick.RemoveAllListeners();
        _minusPower.onClick.RemoveAllListeners();
        _fight.onClick.RemoveAllListeners();

        RemoveEnemy(_enemy);
    }
}
