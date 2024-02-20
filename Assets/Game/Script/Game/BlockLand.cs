using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// block (cell) can contain 1 object
/// </summary>
public class BlockLand : MonoBehaviour
{
    public static BlockLand _curBlock;
    public SpriteRenderer _spriteIcon;
    public GameObject _children;
    public bool _isFull;
    public int row, col;
    public void Init(int row, int col, Sprite sprite)
    {
        this.row = row;
        this.col = col;
        _spriteIcon.sprite = sprite;
    }
    private void OnMouseDown()
    {
        if (_curBlock != this)
        {
            _curBlock = this;
        }
    }
    public void OnMouseUp()
    {
        if (_curBlock != null && GameManager._curBattleCard != null && GameManager._gameState == GameState.PLAYING && !_isFull)
        {
            if (GameManager._curBattleCard._canActive)
            {
                SpawnObj();
            }
        }
    }
    public void SpawnObj()
    {
        DataCard card = GameManager._curBattleCard._data;
        if (GameManager.Instance.CheckEnoughCoin(card._price))
        {
            GameManager._curBattleCard.UsingCard();
            _isFull = true;
            _children = Instantiate(card._ObjPref, transform);
            GameManager.Instance.UpdateCoin(-card._price);
            ObjectBase objectBase = _children.GetComponent<ObjectBase>();
            objectBase.Born();
            _children.transform.localPosition = new Vector3(0, .3f);
        }
        else
        {
            Debug.Log("not enough coins");
        }
    }
}
