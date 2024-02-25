using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// block (cell) can contain 1 object
/// </summary>
public class BlockLand : MonoBehaviour, IPointerClickHandler
{
    public static BlockLand _curBlock;
    public SpriteRenderer _spriteIcon;
    public GameObject _children;
    public bool _isFull;
    public int row, col;
    float _timeClick;
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
        _timeClick = Time.time;
        //   Debug.Log(_isFull + " -- " + _children.activeSelf);
        if (_isFull && !_children.activeSelf && _children != null)
        {
            Destroy(_children);
            _isFull = false;
        }
    }
    public void OnMouseUp()
    {
        if (Time.time - _timeClick < .4f)
        {
            return;
        }
        if (_curBlock != null && PopupGamePlay._curBattleCard != null && GameManager._gameState == GameState.PLAYING && !_isFull)
        {
            if (PopupGamePlay._curBattleCard._canActive)
            {
                SpawnObj();
            }
        }
    }
    public void SpawnObj()
    {
        DataHero card = PopupGamePlay._curBattleCard._data;
        if (PopupGamePlay.CheckEnoughCoin(card._price))
        {
            PopupGamePlay._curBattleCard.UsingCard();
            _isFull = true;
            _children = Instantiate(card._ObjPref, transform);
            PopupGamePlay.UpdateCoin(-card._price);
            ObjectSonTinh objectBase = _children.GetComponent<ObjectSonTinh>();
            Debug.Log(objectBase.name + " -- " + card._name);
            objectBase.Born(card);
            _children.transform.localPosition = new Vector3(0, .3f);
        }
        else
        {
            Debug.Log("not enough coins");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
