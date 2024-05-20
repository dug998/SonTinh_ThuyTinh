using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyVFX : MonoBehaviour
{
    public static CurrencyVFX Instance;
    [HideInInspector]
    public RectTransform transTargetEnergys, transTargetGolds, transTargetGems;
    public ParticleSystem _parGold, _parGems;
    public float _scaleObj;
    float spread;
    public float _spread;
    float minAnimDuration = .5f;
    float maxAnimDuration = 1f;
    [SerializeField] Ease easeType;

    private void Awake()
    {
        Instance = this;
    }
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => PopupCurrencyStatus.Instance != null);
        transTargetEnergys = PopupCurrencyStatus.Instance._iconEnergy.GetComponent<RectTransform>();
        transTargetGolds = PopupCurrencyStatus.Instance._iconGold.GetComponent<RectTransform>();
        transTargetGems = PopupCurrencyStatus.Instance._iconGem.GetComponent<RectTransform>();

    }
    public void InitGolds(RectTransform DesTrans, int AmountGoldTarget)
    {
        StartCoroutine(IEWMoveListObjs(DesTrans, transTargetGolds, AmountGoldTarget));
    }
    public void InitGems(RectTransform DesTrans, int AmountGemTarget)
    {
        StartCoroutine(IEWMoveListObjs(DesTrans, transTargetGems, AmountGemTarget, false));
    }
    IEnumerator IEWMoveListObjs(RectTransform DesTrans, RectTransform TargetTrans, int AmountTarget, bool IsCoins = true)
    {
        List<GameObject> ListObj = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject newObj = CurrencyObjectPool.Instance.Get(IsCoins ? CurrencyObjectPool.Instance.Gold : CurrencyObjectPool.Instance.Gem);
            newObj.gameObject.SetActive(true);
            ListObj.Add(newObj);
            newObj.SetActive(true);
            newObj.transform.position = DesTrans.position;
            newObj.transform.localScale = Vector3.zero;
            newObj.transform.DOScale(_scaleObj, 0.1f);
            newObj.transform.DOMove(DesTrans.position + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f), 0.2f).SetEase(Ease.OutBack).From(DesTrans.position);
        }
        yield return new WaitForSeconds(0.05f);

        for (int i = 0; i < ListObj.Count; i++)
        {
            float duration = Random.Range(minAnimDuration, maxAnimDuration);
            GameObject ObjecPrefab = ListObj[i].gameObject;
            Transform RectCoin = ObjecPrefab.GetComponent<Transform>();
            RectCoin.DOMove(TargetTrans.position, duration)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                ObjecPrefab.SetActive(false);
                CurrencyObjectPool.Instance.Return(ObjecPrefab);
                // SoundHome.instance.PlayShot(SoundHome.instance.Gold, 0.5f);

            });

            yield return new WaitForSeconds(0.04f);
        }
    }
}
