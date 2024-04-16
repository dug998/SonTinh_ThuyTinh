using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestStep1SO", menuName = "ScriptableObjects1/QuestStep1SO")]
public class QuestStepSO : ScriptableObject
{
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public Sprite _spIcon;
    public TypeTask typeTask;
    bool isCollectOrUse;
    [ShowIf("isCollectOrUse")]
    public QuestStepCollectSO questStepCollectSO;

#if UNITY_EDITOR
    private void OnValidate()
    {
        string name = typeTask.ToString();
        if (typeTask == TypeTask.CollectData || typeTask == TypeTask.UseData)
        {
            isCollectOrUse = typeTask == TypeTask.CollectData || typeTask == TypeTask.UseData;
            _spIcon = questStepCollectSO._spIcon;
            name += questStepCollectSO._typeCollect.ToString();
        }

        string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this);
        UnityEditor.AssetDatabase.RenameAsset(assetPath, name);
    }
#endif
}
[System.Serializable]
public class QuestStepCollectSO
{
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public Sprite _spIcon;
    public TypeCollectOrUse _typeCollect;
    public int target;
}
public enum TypeCollectOrUse
{
    Gold,
    Gem
}

public enum TypeTask
{
    CollectData,
    UseData,
    UpgradeSystem,
    Login,
    Logout,
    ProcessRequest,
    UpdateProfile,
    SendEmail
}