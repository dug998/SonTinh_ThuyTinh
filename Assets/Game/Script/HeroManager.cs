using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public static HeroManager Instance;
    [ReadOnly] public List<HeroProfile> _heroProfiles;
    public GameObject _heroObj;
    [Header(" Data Hero Default Own")]
    public List<DataHeroSo> _dataHeroOwn;
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
        if (UserData.firstTimePlayGame)
        {
            UserData.firstTimePlayGame = false;
            SetDefaultOwnedHero();
        }
    }
    public HeroProfile GetHeroProfile()
    {
        return _heroProfiles[0];
    }
    public void SetDefaultOwnedHero()
    {
        if (_dataHeroOwn.Count < 0)
        {
            return;
        }
        foreach (var dataHero in _dataHeroOwn)
        {
            HeroProfile hero = _heroProfiles.Find(x => x.dataHero == dataHero);
            if (hero != null)
            {
                hero.SetOwnHero(true);
            }
        }
    }
}
