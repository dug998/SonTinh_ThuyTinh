using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupListHeros : PopupBase
{
    List<DataHeroSo> _dataHeros;
    public GameObject parentSlotHero;
    public ButtonHeroInfoUi _prefabSlotHeroInfo;
    List<ButtonHeroInfoUi> buttonHeroInfoUis;
    protected override void Awake()
    {
        base.Awake();
        _dataHeros = AssetSO.Instance._dataHeroGames.dataHeros;
        Init();
    }
    public void Init()
    {
        foreach (var hero in _dataHeros)
        {
            ButtonHeroInfoUi btnHero = Instantiate(_prefabSlotHeroInfo, parentSlotHero.transform);
            btnHero.Init(hero);
        }
    }
}
