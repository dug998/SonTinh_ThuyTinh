using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Reward
{
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public Sprite _spIcon;
    public TypeReward typeReward;
    public int valuesRw;
   
}
public enum TypeReward
{
    gold,
    gem,

}
