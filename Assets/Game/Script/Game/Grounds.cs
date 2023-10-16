using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds : MonoBehaviour
{
    [SerializeField] GameObject _blockPref;
    [SerializeField] GameObject _parentBlock;
    public List<BlockLand> Blocks = new List<BlockLand>();
    int _Width = 5;
    int _Height = 9;
    Vector2 _sizeBlock = new Vector2(1.92f, 1.36f);
    [SerializeField] Sprite _block1, _block2;
    public static List<Vector2> _rowLocation = new List<Vector2>();
    public void SpawnBlocks()
    {
        int _heightCenter = _Height / 2;
        int _widthCenter = _Width / 2;
        int index = 0;
        Vector2 pos = Vector2.zero;
        for (int i = 0; i < _Width; i++)
        {

            pos.y = (_widthCenter - i) * _sizeBlock.y;
            for (int j = 0; j < _Height; j++)
            {
                pos.x = (j - _heightCenter) * _sizeBlock.x;
                GameObject obj = Instantiate(_blockPref, pos, Quaternion.identity, _parentBlock.transform);
                obj.GetComponent<BlockLand>().Init(j, i, index % 2 == 0 ? _block1 : _block2);
                index++;
                Blocks.Add(obj.GetComponent<BlockLand>());
            }
            _rowLocation.Add(new Vector2((_Height - _heightCenter) * _sizeBlock.x, pos.y));
        }

    }
}
