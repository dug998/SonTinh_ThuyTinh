using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroesInfo : MonoBehaviour
{
    public Image _avatarHero;
    public TextMeshProUGUI _txtName;
    public void Init(DataCard dataCard)
    {
        _avatarHero.sprite = dataCard._spriteAvatar;
        _avatarHero.SetNativeSize();
        _txtName.text = dataCard._name;
    }
}
