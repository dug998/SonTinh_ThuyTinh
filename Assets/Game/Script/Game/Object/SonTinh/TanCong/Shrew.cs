using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrew : ObjectCounterattack
{
    private float _nextUp;
    public GameObject Shrew_die;
    public override void Born()
    {
        base.Born();
        _nextUp = Random.Range(3, 6);
        StartCoroutine(Attack());
    }
    public override IEnumerator Attack()
    {
        yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);
        yield return new WaitForSeconds(_nextUp);
        _myAnim.SetBool("up", true);
        yield return new WaitForSeconds(1);
        _isHitting = true;

    }

    public override void Move()
    {
    }

    public override void SpawnButtlet()
    {
    }
    protected override void OnTriggerStay2D(Collider2D collision)
    {

    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag(ObjTag.thuyTinh) && _isHitting)
        {
            ObjectBase monsterHealth = collision.GetComponent<ObjectBase>();
            monsterHealth.UpdateHealth(-monsterHealth.GetHealthBase().GetMaxHealth());
            UpdateHealth(-_health.GetMaxHealth());
        }
    }
    public override IEnumerator Die()
    {
        Instantiate(Shrew_die, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
