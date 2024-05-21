
using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "EquipSO", menuName = "Game/EquipSO")]
public class ItemSO : ScriptableObject
{
    [ReadOnly]public string KeyEquip;
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public Sprite so_spIcon;
    public TypeItem so_typeItem;
    public string so_names;
    public Color so_colorBG;
    [TextArea]
    public string so_description;

    //  [VerticalGroup("Combined Column"), LabelWidth(22)]
    // [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    //  public List<Texture> IconLevel;
    public string GetKey()
    {
        return "Key_so_ "+ KeyEquip;
    }
#if UNITY_EDITOR
    //private void OnValidate()
    //{
    //    string fullString = so_spIcon.name;
    //    string searchWord = "icon";

    //    int ringIndex = fullString.IndexOf(searchWord);
    //    KeyEquip = fullString;
    //    if (ringIndex != -1)
    //    {

    //        string result = fullString.Substring(ringIndex + searchWord.Length + 1);
    //        Debug.Log(result); // In ra "Gold"
    //        result = result.Replace("_", " ");

    //        Viết hoa chữ cái đầu
    //       result = char.ToUpper(result[0]) + result.Substring(1);
    //        so_names = result;
    //        string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this);
    //        UnityEditor.AssetDatabase.RenameAsset(assetPath, so_names);
    //    }
    //}
#endif
}