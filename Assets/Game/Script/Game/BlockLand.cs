using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
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
    float _timeClick;
    public int _sortingOrderChild;
    public void Init(int row, int col, Sprite sprite, int __sortingOrder)
    {
        this.row = row;
        this.col = col;
        _spriteIcon.sprite = sprite;
        _sortingOrderChild = __sortingOrder;
    }
    private void OnMouseDown()
    {
        if (_curBlock != this)
        {
            _curBlock = this;
        }
        _timeClick = Time.time;
        if (_isFull && !_children.activeInHierarchy && _children != null)
        {
            Destroy(_children);
            _isFull = false;
        }
    }
    public void RemoveChildren()
    {
        if (_isFull && _children != null)
        {

            Debug.Log("remove");
            Destroy(_children);
            _isFull = false;
        }
    }
    public void OnMouseUp()
    {
        if (Time.time - _timeClick < .2f)
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
        HeroProfile _hero = PopupGamePlay._curBattleCard._heroProfile;
        if (PopupGamePlay.CheckEnoughCoin(_hero._price))
        {
            PopupGamePlay._curBattleCard.UsingCard();
            _isFull = true;
            _children = Instantiate(_hero._objPrefab, transform);
            PopupGamePlay.UpdateCoin(-_hero._price);
            ObjectSonTinh objectBase = _children.GetComponent<ObjectSonTinh>();
            LogGame.Log(objectBase.name + " -- " + _hero._price);

            objectBase.Born(_hero);
            objectBase.SetSortingOrder(_sortingOrderChild);
            _children.transform.localPosition = new Vector3(0, .2f);
        }
        else
        {

            PopupController.Instance.ShowPopup(TypePopup.PopupNotife, new DataMessage(TypeMessage.Error, "", " Not enough coins !"));
            LogGame.LogError(" Not enough coins");
        }
    }

}
