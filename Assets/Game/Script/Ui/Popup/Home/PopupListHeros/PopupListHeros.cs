using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupListHeros : PopupBase
{
    List<HeroProfile> heroProfiles;
    public GameObject parentSlotHero;
    public ButtonHeroInfoUi _prefabSlotHeroInfo;
    List<ButtonHeroInfoUi> buttonHeroInfoUis;
    protected override void Awake()
    {
        base.Awake();
        heroProfiles = HeroManager.Instance._heroProfiles;
        Init();
    }
    public void Init()
    {
        foreach (var hero in heroProfiles)
        {
            ButtonHeroInfoUi btnHero = Instantiate(_prefabSlotHeroInfo, parentSlotHero.transform);
            btnHero.Init(hero);
        }
    }
}
