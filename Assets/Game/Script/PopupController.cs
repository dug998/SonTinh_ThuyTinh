using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static PopupController Instance;
    public PopupLoading _popupLoading;

    [Header(" --- Home --- "), Space(20)]
    public PopupHome _popupHome;


    public PopupChoiceLevel _popupChoiceLevel;
    public PopupChoiceHero _popupChoiceHero;
    public PopupDailyMonth _popupDailyMonth;
    public PopupInfoHeros _popupInfoHeros;
    public PopupListHeros _popupListHeros;
    public PopupShop _popupShop;
    public PopupMission _popupMission;
    public PopupSetting _popupSetting;
    public PopupInventory _popupInventory;
    public PopupReward _popupReward;
    public PopupUpgradeHero _popupUpgradeHero;

    [Header(" --- Game Play --- "), Space(20)]

    public PopupGamePlay _popupGamePlay;
    public PopupWinGame _popupWinGame;
    public PopupLose _popupLose;

    public void Init()
    {
        Instance = this;
        gameObject.SetActive(true);
    }
    public void ShowPopup(TypePopup _typePopup, object data = null)
    {
        PopupBase popup = GetPopup(_typePopup);

        popup.Show(data);


    }
    public void HidePopup(TypePopup _typePopup)
    {
        PopupBase popup = GetPopup(_typePopup);

        popup.Hide();
    }
    PopupBase GetPopup(TypePopup _typePopup)
    {
        PopupBase popup = null;
        switch (_typePopup)
        {
            case TypePopup.PopupGamePlay:
                popup = _popupGamePlay;
                break;
            case TypePopup.PopupWinGame:
                popup = _popupWinGame;
                break;
            case TypePopup.PopupLose:
                popup = _popupLose;
                break;


            case TypePopup.PopupHome:
                popup = _popupHome;
                break;
            case TypePopup.PopupLoading:
                popup = _popupLoading;
                break;
            case TypePopup.PopupChoiceLevel:
                popup = _popupChoiceLevel;
                break;
            case TypePopup.PopupChoiceHero:
                popup = _popupChoiceHero;
                break;

            case TypePopup.PopupDailyMonth:
                popup = _popupDailyMonth;
                break;
            case TypePopup.PopupInfoHeros:
                popup = _popupInfoHeros;
                break;
            case TypePopup.PopupShop:
                popup = _popupShop;
                break;
            case TypePopup.PopupMission:
                popup = _popupMission;
                break;
            case TypePopup.PopupSetting:
                popup = _popupSetting;
                break;
            case TypePopup.PopupListHeros:
                popup = _popupListHeros;
                break;
            case TypePopup.PopupInventory:
                popup = _popupInventory;
                break;
            case TypePopup.PopupUpgradeHero:
                popup = _popupUpgradeHero;
                break;
            default:
                popup = _popupHome;
                break;
        }
        return popup;
    }
}
public enum TypePopup
{

    PopupGamePlay,
    PopupWinGame,
    PopupLose,

    PopupHome,
    PopupLoading,
    PopupChoiceLevel,
    PopupChoiceHero,
    PopupDailyMonth,
    PopupInfoHeros,
    PopupShop,
    PopupMission,
    PopupSetting,
    PopupListHeros,
    PopupInventory,
    PopupUpgradeHero
}
