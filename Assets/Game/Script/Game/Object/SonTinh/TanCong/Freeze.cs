using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : ObjectCounterAttack
{
    public List<GameObject> direcBullets;
    public override IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);
            yield return new WaitUntil(() => _isHitting);
            yield return new WaitForSeconds(.5f);
            yield return new WaitForSeconds(.5f);
            SpawnButtlet();
            yield return new WaitForSeconds(.5f);
        }
    }

    public override void SpawnButtlet()
    {
        foreach (var direc in direcBullets)
        {
            var obj = Instantiate(_bulletPref, _locationAppears.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            obj.GetComponent<ObjectBase>().SetSpeed((direc.transform.position - _locationAppears.position).normalized);


        }
    }
}
