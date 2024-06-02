using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : ObjectExploit
{
    public override IEnumerator StartExploit()
    {
        yield return new WaitForSeconds(_nextExploit);
        while (true)
        {
            yield return new WaitUntil(() => (GameManager._gameState == GameState.PLAYING && !_canHarvert));
            yield return new WaitForSeconds(_nextExploit);
            ManufactureResource();
        }

    }
    public override void ManufactureResource()
    {
        base.ManufactureResource();
        GameObject obj = Instantiate(_resourcesPref, transform);
        obj.transform.position = _locationAppears.position;
        obj.GetComponent<Coin>()._parrent = gameObject;
        obj.GetComponent<Coin>()._typeCoin = _typeCoin;
    }

    public override void Move()
    {

    }
}
