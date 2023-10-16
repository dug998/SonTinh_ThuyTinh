using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (_curBlock != null && GameManager._CardSelect != null && GameManager._gameState == GameState.PLAYING && !_isFull)
        {
            _isFull = true;
            SpawnObj();
        }
    }
    public void SpawnObj()
    {
        DataCard card = GameManager._CardSelect;

        _children = Instantiate(card._ObjPref, transform);
        ObjectBase objectBase = _children.GetComponent<ObjectBase>();
        objectBase.Born();
        _children.transform.localPosition = new Vector3(0, .3f);
    }
}
