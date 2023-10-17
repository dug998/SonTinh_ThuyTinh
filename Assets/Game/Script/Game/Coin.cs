using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int _values;
    public TypeCoin _typeCoin;
    public GameObject _parrent;
    public void DoMove(Vector2 from, Vector2 to, float duration)
    {
        transform.DOKill();
        transform.DOMove(to, duration).From(from).SetEase(Ease.OutCubic);
    }
    public void TakeCoin(Vector2 target)
    {
        transform.DOKill();
        transform.DOMove(target, 2).OnComplete(() =>
        {
            GameManager.Instance.UpdateCoin(_values);
            Destroy(gameObject);
        });

        if (_typeCoin == TypeCoin.exploit)
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
