using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataHeroGames", menuName = "Game/DataHeroGames")]
public class DataHeroGames : ScriptableObject
{
    public List<DataHeroSo> dataHeros = new List<DataHeroSo>();
    //private void OnValidate()
    //{
    //    foreach (var card in dataHeros)
    //    {
    //        card.so_spriteCard = card._spriteiIcon;
    //    }
    //}
}

