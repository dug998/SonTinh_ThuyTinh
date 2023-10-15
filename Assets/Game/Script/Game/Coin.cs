using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int _values;

    public void TakeCoin(Vector2 target)
    {
        transform.DOMove(target, 2).OnComplete(() =>
        {
            GameManager.Instance.UpdateCoin(_values);
        });

    }

}
