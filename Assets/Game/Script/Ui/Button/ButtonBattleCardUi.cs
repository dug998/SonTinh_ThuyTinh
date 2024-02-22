using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBattleCardUi : ButtonBase
{
    [Header("___ Data ___"), Space(20)]
    public DataCard _data;
    public bool _canUse;
    public bool _canActive = false;
    public int _price;
    public float _duration;
    [Header("____ Ui ___"), Space(20)]
    [SerializeField] Image _iconCard;
    [SerializeField] Image _activeImgFill;
    [SerializeField] Image _ImgOff;
    [SerializeField] Text _txtPrice;
    protected override void Awake()
    {
        AddEvent(OnClick);
    }
    public override void Init(object data)
    {
        _data = (DataCard)data;
        _iconCard.sprite = _data._spriteCard;
        _price = _data._price;
        _canActive = true;
        _txtPrice.text = _price.ToString();
        _duration = _data._timeRecoveryCard;

    }
    private void OnEnable()
    {
        GameEvent.changeCoin += UpdateStatusCard;
    }
    private void OnDisable()
    {
        GameEvent.changeCoin -= UpdateStatusCard;
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
        print(_data._id + " : " + _data._title);
        GameManager._curBattleCard = this;
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
