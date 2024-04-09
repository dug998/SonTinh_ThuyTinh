using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupCurrencyStatus : PopupBase
{
    public static PopupCurrencyStatus Instance;

    [TitleGroup("Energy", "Optional subtitle", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: false)]
    public TextMeshProUGUI _txtValuesEnergy;
    public Button _btnAddEnergy;
    public GameObject _iconEnergy;

    [TitleGroup("Gem", "Optional subtitle", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: false)]
    public TextMeshProUGUI _txtValuesGem;
    public Button _btnAddGem;
    public GameObject _iconGem;

    [TitleGroup("Gold", "Optional subtitle", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: false)]
    public TextMeshProUGUI _txtValuesGold;
    public Button _btnAddGold;
    public GameObject _iconGold;

    protected override void Awake()
    {
        Instance = this;
        UpdateCurrencyStatus();
    }
    private void OnEnable()
    {
        EventGame.UpdateCurrencyStatus += UpdateCurrencyStatus;
    }
    private void OnDisable()
    {
        EventGame.UpdateCurrencyStatus -= UpdateCurrencyStatus;
    }
    public void UpdateCurrencyStatus()
    {
        _txtValuesEnergy.text = UserData.EnergyGame + "";
        _txtValuesGem.text = UserData.GemGame + "";
        _txtValuesGold.text = UserData.GoldGame + "";
    }

}
