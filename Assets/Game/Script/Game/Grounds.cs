using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Soil consists of many blocks (soil cells) that have the function of generating desired blocks
/// </summary>
public class Grounds : MonoBehaviour
{
    [SerializeField] GameObject _blockPref;
    [SerializeField] GameObject _parentBlock;
    public List<BlockLand> Blocks = new List<BlockLand>();
    public static int _Width = 5;
    public static int _Height = 9;
    Vector2 _sizeBlock = new Vector2(1.32f, 1.56f);
    [SerializeField] Sprite _block1, _block2;
    public static List<Vector2> _rowLocation = new List<Vector2>();
    public void SpawnBlocks()
    {
        int _sortingOrder;
        int _heightCenter = _Height / 2;
        int _widthCenter = _Width / 2;
        int index = 0;
        Vector2 pos = Vector2.zero;
        for (int i = 0; i < _Width; i++)
        {
            _sortingOrder = 20 + i;
            pos.y = (_widthCenter - i) * _sizeBlock.y;

            for (int j = 0; j < _Height; j++)
            {
                pos.x = (j - _heightCenter) * _sizeBlock.x;
                BlockLand obj = Instantiate(_blockPref, pos, Quaternion.identity, _parentBlock.transform).GetComponent<BlockLand>();
                obj.Init(j, i, index % 2 == 0 ? _block1 : _block2, _sortingOrder);
                index++;
                Blocks.Add(obj);
            }
            _rowLocation.Add(new Vector2((_Height - _heightCenter) * _sizeBlock.x, pos.y));
        }

    }
    public BlockLand GetBlockLand(int row, int coll)
    {
        return Blocks.Find(x => x.row == row && x.col == coll);
    }
}
