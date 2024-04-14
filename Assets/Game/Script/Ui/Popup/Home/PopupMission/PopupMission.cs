using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMission : PopupBase
{
    public static ButtonUi _currBtnTap;
    public static GameObject _currObj;

    public GameObject _tabFocusLine;

    public ButtonUi _btnTabDaily;
    public ButtonUi _btnTabAcheivement;
    public GameObject ObjDaily, ObjAcheivement;

    public List<QuestTapUi> questTapUiList;
    protected override void Awake()
    {
        base.Awake();
        _btnTabDaily.AddEvent(() =>
        {
            OnClickTab(ObjDaily, _btnTabDaily);
        });
        _btnTabAcheivement.AddEvent(() =>
        {
            OnClickTab(ObjAcheivement, _btnTabAcheivement);
        }
        );
    }
    public void OnClickTab(GameObject objNew, ButtonUi btnTapNew)
    {
        if (_currObj != null) { _currObj.SetActive(false); }
        if (_currBtnTap != null) { _currBtnTap.Activity(false); }

        _currBtnTap = btnTapNew;
        _currObj = objNew;

        _currObj.SetActive(true);
        _currBtnTap.Activity(true);

        _tabFocusLine.transform.DOKill(true);
        _tabFocusLine.transform.DOMoveY(_currBtnTap.transform.position.y, .3f);


    }
    public override void Show(object data = null)
    {
        base.Show(data);
        Dictionary<string, Quest> questMap = QuestGameManager.instance.questMap;
        int index = 0;
        foreach (var quest in questMap.Values)
        {
            if (index > questTapUiList.Count)
                break;

            questTapUiList[index].Init(quest);
            index++;
        }
    }
}
