using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCardGame", menuName = "Game/DataCardGame")]
public class DataCardGame : ScriptableObject
{
    public List<DataCard> dataCards = new List<DataCard>();
}
[System.Serializable]
public class DataCard
{
    public int _id;
    public string _title;
    public string _description;
    public int _price;
    public float _timeRecoveryCard;
    public Sprite _spriteiIcon;
    public GameObject _ObjPref;
}
