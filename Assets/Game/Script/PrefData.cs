using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefData
{

    public static int maxNumberCardBattle
    {
        get
        {
            return PlayerPrefs.GetInt("KeyMaxNumberCardBattle", 2);
        }
        set
        {

            PlayerPrefs.SetInt("KeyMaxNumberCardBattle", value);
        }
    }
}
