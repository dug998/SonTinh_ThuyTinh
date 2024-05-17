using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarHeroUi : MonoBehaviour
{
    public List<GameObject> _listStart;
    public Sprite sp_StartOn, sp_StartOff;

    public void Show(int numberStartShow)
    {
        numberStartShow = Mathf.Clamp(numberStartShow, 0, _listStart.Count);
        for (int i = 0; i < _listStart.Count; i++)
        {
            _listStart[i].GetComponent<Image>().sprite = i < numberStartShow ? sp_StartOn : sp_StartOff;

        }
    }

}
