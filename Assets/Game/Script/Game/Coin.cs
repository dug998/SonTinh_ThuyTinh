using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int _values;
    public TypeCoin _typeCoin;
    public GameObject _parrent;
    bool _received = false;
    public void OnEnable()
    {
        _received = false;
        Invoke(nameof(Destroy), 5);
    }
    public void Destroy()
    {
      
        if (_received && _typeCoin != TypeCoin.exploit)
        {
            return;
        }
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        transform.DOKill();
    }
    public void DoMove(Vector2 from, Vector2 to, float duration)
    {
        transform.DOKill();
        transform.DOMove(to, duration).From(from).SetEase(Ease.OutCubic);
    }
    public void TakeCoin(Vector2 target)
    {
        if (_received)
        {
            return;
        }
        _received = true;
        transform.DOKill();
        transform.DOMove(target, 2).OnComplete(() =>
        {
            PopupGamePlay.UpdateCoin(_values);
            Destroy(gameObject);
        });

        if (_typeCoin == TypeCoin.exploit && _parrent != null)
        {
            ObjectExploit objectExploit = _parrent.GetComponent<ObjectExploit>();
            objectExploit.Harvest();
            _parrent = null;
        }

    }

}
public enum TypeCoin
{
    nature,
    exploit,
}
