using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : ObjectExploit
{
    public override IEnumerator Exploit()
    {
        yield return new WaitForSeconds(_timeExploit);
        while (true)
        {
            yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);
            SpawnResource();
            yield return new WaitForSeconds(_timeExploit);
        }

    }
    public override void SpawnResource()
    {
        GameObject obj = Instantiate(_resourcesPref);
        obj.transform.position = _locationAppears.position;
    }
    public override void Die()
    {
        StopCoroutine(Exploit());

    }

    public override void Move()
    {

    }

   
}
