using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Reward
{
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public ItemSO _ItemSO;
    public int _valuesRw;

}
public enum TypeItem
{
    none,
    gold,
    gem,


}
