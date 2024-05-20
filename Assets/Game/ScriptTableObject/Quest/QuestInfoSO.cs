using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "ScriptableObjects/QuestInfoSO")]

public class QuestInfoSO : ScriptableObject
{
    public string id;
    [Header("General")]
    public string displayName;

    [Header("Requirements")]
    public int levelRequirement;
    public QuestInfoSO[] questPrerequisites;

    [Header("Steps")]
    public List<QuestStepSO> questStepPrefabs;

    [Header("Rewards")]
    public Reward _itemRewards;
#if UNITY_EDITOR
    private void OnValidate()
    {
        string name = "Quest_" + id;
        string path = UnityEditor.AssetDatabase.GetAssetPath(this);
        UnityEditor.AssetDatabase.RenameAsset(path, name);
    }
#endif
}
