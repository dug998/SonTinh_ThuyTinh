using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBattleHeroUi : ButtonBase
{
    [Header("___ Data ___"), Space(20)]
    public HeroProfile _heroProfile;
    public bool _canUse;
    public bool _canActive = false;
    public int _price;
    public float _duration;
    [Header("____ Ui ___"), Space(20)]
    [SerializeField] Image _iconCard;
    [SerializeField] Image _activeImgFill;
    [SerializeField] Image _ImgOff;
    [SerializeField] TextMeshProUGUI _txtPrice;
    protected override void Awake()
    {
        AddEvent(OnClick);
    }
    public override void Init(object data)
    {
        _heroProfile = (HeroProfile)data;
        DataHeroSo _data = _heroProfile.dataHero;
        _iconCard.sprite = _data.so_spriteCard;
        _price = _data.so_price;
        _canActive = true;
        _txtPrice.text = _price.ToString();
        _duration = _data.so_timeRecoveryCard;

    }
    private void OnEnable()
    {
        EventGame.changeCoin += UpdateStatusCard;
    }
    private void OnDisable()
    {
        EventGame.changeCoin -= UpdateStatusCard;
    }
    public void UpdateStatusCard(int CurCoin)
    {

        // lấy ra sử dụng

        _canUse = CurCoin >= _price;

        _ImgOff.gameObject.SetActive(!_canUse);

    }
    public void OnClick()
    {
        if (!_canUse)
        {
            Debug.Log(" no use ");
         
            return;
        }
        if (!_canActive)
        {
            Debug.Log("No  Active");
            return;
        }
      //  print(_dataReward.so_id + " : " + _dataReward.so_title);
        PopupGamePlay._curBattleCard = this;
        PopupController.Instance._popupGamePlay.SetFocus();
    }
    public void SetFocus(GameObject _focus)
    {
        _focus.transform.DOKill(true);
        _focus.SetActive(true);
        _focus.transform.DOMove(transform.position, 0.1f).OnComplete(() =>
        {
            _focus.transform.SetParent(transform);
        });
    }
    public void UsingCard()
    {
        _canActive = false;
        Debug.Log("  Active");
        _activeImgFill.DOKill();
        _activeImgFill.DOFillAmount(0, _duration).From(1).SetEase(Ease.Linear).OnComplete(() =>
        {
            Debug.Log("  Active 2");
            _canActive = true;
        });
    }
}
