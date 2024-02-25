using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataHeroGames", menuName = "Game/DataHeroGames")]
public class DataHeroGames : ScriptableObject
{
    public List<DataHero> dataHeros = new List<DataHero>();
    //private void OnValidate()
    //{
    //    foreach (var card in dataHeros)
    //    {
    //        card._spriteCard = card._spriteiIcon;
    //    }
    //}
}

