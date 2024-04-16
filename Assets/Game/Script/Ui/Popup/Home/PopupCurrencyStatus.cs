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
    int _currValuesEnergy;
    [TitleGroup("Gem", "Optional subtitle", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: false)]
    public TextMeshProUGUI _txtValuesGem;
    public Button _btnAddGem;
    public GameObject _iconGem;
    public int _currValuesGem;
    [TitleGroup("Gold", "Optional subtitle", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: false)]
    public TextMeshProUGUI _txtValuesGold;
    public Button _btnAddGold;
    public GameObject _iconGold;
    public int _currValuesGold;
    protected override void Awake()
    {
        Instance = this;
        _currValuesGold = UserData.GoldGame;
        _currValuesGem = UserData.GemGame;


        _txtValuesEnergy.text = UserData.EnergyGame + "";
        _txtValuesGem.text = UserData.GemGame + "";
        _txtValuesGold.text = UserData.GoldGame + "";
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
        if (UserData.GoldGame - _currValuesGold != 0)
        {
            QuestEvents.UpdateCollected(UserData.GoldGame - _currValuesGold, TypeCollectOrUse.Gold);
        }
        if (UserData.GemGame - _currValuesGem != 0)
        {
            QuestEvents.UpdateCollected(UserData.GemGame - _currValuesGem, TypeCollectOrUse.Gem);

        }

        _currValuesGold = UserData.GoldGame;
        _currValuesGem = UserData.GemGame;

        _txtValuesEnergy.text = UserData.EnergyGame + "";
        _txtValuesGem.text = UserData.GemGame + "";
        _txtValuesGold.text = UserData.GoldGame + "";
    }
}
