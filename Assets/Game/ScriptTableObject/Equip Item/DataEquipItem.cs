using Sirenix.OdinInspector.Editor.Examples;
using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "DataEquip", menuName = "Game/DataEquip")]
public class DataEquipItem : ScriptableObject
{
    [HideInInlineEditors]string KeyEquip;
    [TableColumnWidth(57, Resizable = false)]
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public Sprite Icon;
    public string Names;
    public Color ColorBG;
    [TextArea]
    public string Description;

    [VerticalGroup("Combined Column"), LabelWidth(22)]
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public List<Texture> IconLevel;
    public string GetKey()
    {
        return KeyEquip;
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        string fullString = Icon.name;
        string searchWord = "icon";

        int ringIndex = fullString.IndexOf(searchWord);
        KeyEquip = fullString;
        if (ringIndex != -1)
        {


            string result = fullString.Substring(ringIndex + searchWord.Length + 1);
            Debug.Log(result); // In ra "Gold"
            result = result.Replace("_", " ");

            // Viết hoa chữ cái đầu
            result = char.ToUpper(result[0]) + result.Substring(1);
            Names = result;
            string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this);
            UnityEditor.AssetDatabase.RenameAsset(assetPath, Names);
        }
    }
#endif
}
