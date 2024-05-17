using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroesInfoUi : MonoBehaviour
{
    public static HeroProfile _curHeroProfile;
    public Image _avatarHero;
    public TextMeshProUGUI _txtName;
    [Header(" -- stat --")]
    public StatHeroUi _StatHeroHp;
    public StatHeroUi _StatHeroDamage;
    public StatHeroUi _StatHeroDefense;
    public void Init(HeroProfile heroProfile)
    {
        if (_curHeroProfile == heroProfile)
        {
            return;
        }
        _curHeroProfile = heroProfile;
        DataHeroSo dataHero = _curHeroProfile.dataHero;
        _avatarHero.sprite = dataHero.so_spriteAvatar;
        _avatarHero.SetNativeSize();
        _txtName.text = dataHero.so_name;

        _StatHeroHp.UpdateStat(heroProfile._currentHp, heroProfile._MaxtHp);
        _StatHeroDamage.UpdateStat(heroProfile._currentDame, heroProfile._MaxtDame);
        _StatHeroDefense.UpdateStat(heroProfile._currentDefense, heroProfile._MaxtDefense);

    }

}
