using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : ObjectAttackTT
{
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

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void Move()
    {
        if (_stand)
        {
            _myBody.velocity = new Vector2(0, _myBody.velocity.y);
            _myAnim.SetBool("walk", false);
        }
        else
        {
            _myBody.velocity = new Vector2(-speed * move, _myBody.velocity.y);
            _myAnim.SetBool("walk", true);
        }
    }

    public override void SpawnButtlet()
    {
        Instantiate(_bulletPref, _locationAppears.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    public void FixedUpdate()
    {
        Move();
    }
}
