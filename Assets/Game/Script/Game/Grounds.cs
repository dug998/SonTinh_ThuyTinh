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
    [ContextMenu("SpawnBlocks")]
    public void SpawnBlocks()
    {
        int _heightCenter = _Height / 2;
        int _widthCenter = _Width / 2;
        int index = 0;
        Vector2 pos = Vector2.zero;
        for (int i = 0; i < _Height; i++)
        {

            pos.x = (_heightCenter - i) * _sizeBlock.x;
            for (int j = 0; j < _Width; j++)
            {
                pos.y = (_widthCenter - j) * _sizeBlock.y;
                GameObject obj = Instantiate(_blockPref, pos, Quaternion.identity, _parentBlock.transform);
                obj.GetComponent<BlockLand>().Init(index % 2 == 0 ? _block1 : _block2);
                index++;
                Blocks.Add(obj.GetComponent<BlockLand>());
            }
        }

    }
}
