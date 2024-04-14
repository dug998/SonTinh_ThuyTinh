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
    bool isCollectData;
    [ShowIf("isCollectData")]
    public QuestStepCollectSO questStepCollectSO;

    private void OnValidate()
    {
        string name = typeTask.ToString();
        if (typeTask == TypeTask.CollectData)
        {
            isCollectData = typeTask == TypeTask.CollectData;
            _spIcon = questStepCollectSO._spIcon;
            name += questStepCollectSO._typeCollect.ToString();
        }
        string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this);
        UnityEditor.AssetDatabase.RenameAsset(assetPath, name);
    }
}
[System.Serializable]
public class QuestStepCollectSO
{
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public Sprite _spIcon;
    public TypeCollect _typeCollect;
    public int target;
}
public enum TypeCollect
{
    Gold,
    Gem
}
public enum TypeTask
{
    CollectData,
    UpgradeSystem,
    Login,
    Logout,
    ProcessRequest,
    UpdateProfile,
    SendEmail
}