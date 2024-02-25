using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTower : ObjectBase
{
    public static HomeTower Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public override IEnumerator EffectDie()
    {
        yield return null;
        if (GameManager._gameState != GameState.PLAYING)
        {
            yield break;
        }
        GameManager.Instance.EndGame(GameState.LOSE_GAME);
        Debug.Log("Lose");

    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }
}
