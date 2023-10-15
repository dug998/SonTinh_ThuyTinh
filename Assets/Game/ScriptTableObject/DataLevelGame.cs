using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataLevelGame", menuName = "Game/DataLevelGame")]
public class DataLevelGame : ScriptableObject
{
 
    public List<DataLevel> dataLevels = new List<DataLevel>();
}
[System.Serializable]
public class DataLevel
{
    public int _id;
    public string _title;
    public string _description;
    public Sprite _spriteiIcon;
}