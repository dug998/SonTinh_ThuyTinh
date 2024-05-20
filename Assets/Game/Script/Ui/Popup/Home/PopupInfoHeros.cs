using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupInfoHeros : PopupBase
{
    HeroProfile _heroProfile;
    public Image _iconAvatarHero;
    [Header(" --- ChracterInfo ---")]
    [Header(" --- Star ---")]
    public StarHeroUi _starHeroUi;
    [Header(" ---- Right_Panel --- ")]
    [Header(" SelectCharacterInfo "), Space(20)]
    public Image _imgRoleIcon;
    public TextMeshProUGUI _txtName, _txtDesc, _txtRole;

    [Header(" CharacterLevel "), Space(20)]
    public Slider _sliderExp;
    public TextMeshProUGUI _txtLevelNum, _txtExp;

    [Header(" Stat "), Space(20)]
    public StatHeroUi _StatHeroHp;
    public StatHeroUi _StatHeroDamage;
    public StatHeroUi _StatHeroDefense;

    public ButtonUi _btnUpgrade;
    protected override void Awake()
    {
        base.Awake();
        _btnUpgrade.AddEvent(OnClickUpgrade);
    }
    public void OnClickUpgrade()
    {
        if (_heroProfile == null) return;

        PopupController.Instance.ShowPopup(TypePopup.PopupUpgradeHero, _heroProfile);

    }
    public override void Show(object data = null)
    {
        base.Show(data);
        Init(data);
    }
    public void Init(object data = null)
    {
        _heroProfile = (HeroProfile)data;
        DataHeroSo dataHero = _heroProfile.dataHero;
        _starHeroUi.ShowStatMax(_heroProfile._maxStart);
        _starHeroUi.Show(_heroProfile._currentStart);
        _txtName.text = dataHero.so_name;
        _iconAvatarHero.sprite = dataHero.so_spriteAvatar;
        _iconAvatarHero.SetNativeSize();
        _txtDesc.text = dataHero.so_description;

        _StatHeroHp.UpdateStat(_heroProfile._currentHp, _heroProfile._MaxtHp);
        _StatHeroDamage.UpdateStat(_heroProfile._currentDame, _heroProfile._MaxtDame);
        _StatHeroDefense.UpdateStat(_heroProfile._currentDefense, _heroProfile._MaxtDefense);
    }
    float ValuesSlider(float cur, float max)
    {
        return cur / max;
    }

}
