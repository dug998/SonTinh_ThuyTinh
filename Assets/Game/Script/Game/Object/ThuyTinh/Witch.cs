using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : ObjectThuyTinh
{
    int _rowLand, _colLand;
    public float _nextSpawn = 10, _spawnRate = 3;
    public GameObject _monster;
    Grounds _grounds;
    public override void Born(Object data = null)
    {
        base.Born(data);
        _grounds = GameManager.Instance._curLevelGame._grounds;
        InvokeRepeating(nameof(Spawn), _spawnRate, _nextSpawn);
    }
    public virtual void Spawn()
    {

        // spawn up 
        var block = _grounds.GetBlockLand(_rowLand + 1, _colLand + 1);
        if (block == null)
        {
            return;
        }
        SpawnThuyTinh.Instance.SpawnObj(_monster, block.transform.position);
    }
    public override IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);
            yield return new WaitUntil(() => _isHitting);
            yield return new WaitForSeconds(.5f);
            _myAnim.SetBool("hit", true);
            yield return new WaitForSeconds(.5f);
            SpawnButtlet();
            yield return new WaitForSeconds(.5f);
            _myAnim.SetBool("hit", false);
        }
    }

    public override void SpawnButtlet()
    {
        Instantiate(_bulletPref, _locationAppears.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("Tile"))
        {
            var block = collision.GetComponent<BlockLand>();
            _rowLand = block.row;
            _colLand = block.col;
        }

    }
}
