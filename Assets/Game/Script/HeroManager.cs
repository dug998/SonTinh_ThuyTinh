using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public static HeroManager Instance;
    [ReadOnly] public List<HeroProfile> _heroProfiles;
    public GameObject _heroObj;
    private void Awake()
    {
        Instance = this;
    }
    IEnumerator Start()
    {
        yield return new WaitUntil(() => AssetSO.Instance != null);
        List<DataHeroSo> _dataHeroGames = AssetSO.Instance._dataHeroGames.dataHeros;
        foreach (var dataHero in _dataHeroGames)
        {
            HeroProfile profile = Instantiate(_heroObj, transform).GetComponent<HeroProfile>();
            profile.Init(dataHero);
            _heroProfiles.Add(profile);
        }
    }
    public HeroProfile GetHeroProfile()
    {
        return _heroProfiles[0];
    }
}
