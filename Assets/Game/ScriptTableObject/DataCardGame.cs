using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCardGame", menuName = "Game/DataCardGame")]
public class DataCardGame : ScriptableObject
{
    public List<DataCard> dataCards = new List<DataCard>();
    //private void OnValidate()
    //{
    //    foreach (var card in dataCards)
    //    {
    //        card._spriteCard = card._spriteiIcon;
    //    }
    //}
}
[System.Serializable]
public class DataCard
{
    public int _id;
    public string _title;
    public string _name;
    public string _description;
    public int _price;
    public float _timeRecoveryCard;
    public Sprite _spriteAvatar;
    public Sprite _spriteCard;
    public GameObject _ObjPref;

}

