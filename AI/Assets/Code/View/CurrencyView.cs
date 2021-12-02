using UnityEngine;
using TMPro;

public class CurrencyView : MonoBehaviour
{
    private const string TreeKey = nameof(TreeKey);
    private const string MolotKey = nameof(MolotKey);

    public static CurrencyView Instance;

    [SerializeField] private TMP_Text _currentCountTree;
    [SerializeField] private TMP_Text _currentCountMolot;

    private int Tree 
    {
        get => PlayerPrefs.GetInt(TreeKey, 0);
        set => PlayerPrefs.SetInt(TreeKey, value);
    }

    private int Molot
    {
        get => PlayerPrefs.GetInt(MolotKey, 0);
        set => PlayerPrefs.SetInt(MolotKey, value);
    }

    private void Awake() => Instance = this;
    private void Start()
    {
        RefreshText();
    }

    public void AddTree(int value)
    {
        Tree += value;
        RefreshText();
    }

    public void AddMolot(int value)
    {
        Molot += value;
        RefreshText();
    }

    private void RefreshText()
    {
        _currentCountTree.text = Tree.ToString();
        _currentCountMolot.text = Molot.ToString();
    }
}
