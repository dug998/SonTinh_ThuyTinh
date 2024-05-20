using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : ObjectCounterAttack
{
    [ReadOnly]public ObjectThuyTinh _objectThuyTinh;
    public override IEnumerator Attack()
    {
        yield return null;
        while (true)
        {
            _myAnim.SetBool("hit", false);
            yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);
            yield return new WaitUntil(() => _isHitting);

            yield return new WaitForSeconds(.5f);
            _myAnim.SetBool("hit", true);
            yield return new WaitForSeconds(.5f);
            if (_objectThuyTinh != null)
            {
                _objectThuyTinh.DiedImmediate();
                _objectThuyTinh = null;
            }
            yield return new WaitForSeconds(Random.RandomRange(20, 30));
            _myAnim.SetBool("hit", false);
            yield return new WaitForSeconds(_nextHitting);
        }
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag.thuyTinh))
        {
            _isHitting = false;
            if (_objectThuyTinh != null)
            {
                _objectThuyTinh = null;
            }
        }

    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag(ObjTag.thuyTinh))
        {
            _isHitting = true;
            if (_objectThuyTinh == null)
            {
                _objectThuyTinh = collision.GetComponent<ObjectThuyTinh>();
            }
        }
    }

    public override void SpawnButtlets()
    {
        throw new System.NotImplementedException();
    }
}
