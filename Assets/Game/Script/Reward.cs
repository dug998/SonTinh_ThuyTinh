using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Reward
{
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    [OnValueChanged("OnChanged")]
    public ItemSO _ItemSO;
    [ReadOnly] public string so_names;
    public int _valuesRw;

    private void OnChanged()
    {
        this.so_names = _ItemSO.so_names;
    }
}

public enum TypeItem
{
    none,
    gold,
    gem,


}
