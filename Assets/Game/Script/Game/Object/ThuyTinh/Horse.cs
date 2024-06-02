using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Horse : ObjectThuyTinh
{
    [ReadOnly] protected bool _isJump = false;
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
    public override void Born(Object data = null)
    {
        base.Born(data);
        _isJump = false;
    }

    public override IEnumerator EffectDie()
    {
        _myColli.enabled = false;
        SpawnThuyTinh.Instance?.RemoveMonster(this);

        _Dead.PixelGravityDie(1);
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }

    public override void SpawnButtlet()
    {
        Instantiate(_bulletPref, _locationAppears.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
  
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        if (collision.gameObject.CompareTag(ObjTag.sonTinh) && collision.isTrigger == true)
        {
           
            if (collision.gameObject.layer == LayerMask.NameToLayer("Stone"))
            {
                _isJump = true;
            }
            if (!_isJump)
            {
               // transform.position = new Vector2(transform.position.x - 2.5f, transform.position.y);
                transform.DOJump(new Vector2(transform.position.x - 2.5f, transform.position.y), 1, 1, 1);
                currSpeed *= 0.5f;
                _isJump = true;
            }
            else
            {
                _isHitting = true;
                _isStand = true;
            }
        }
    }
    // Start is called before the first frame update

}
