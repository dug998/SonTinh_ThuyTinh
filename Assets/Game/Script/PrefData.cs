using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefData
{
    #region Setting
    public static bool turnOffMusic
    {
        get
        {
            return PlayerPrefs.GetInt("KeyTurnOffMusic", 1) == 1;
        }
        set
        {

            PlayerPrefs.SetInt("KeyTurnOffMusic", value ? 1 : 0);
        }
    }
    public static bool turnOffSound
    {
        get
        {
            return PlayerPrefs.GetInt("KeyTurnOffSound", 1) == 1;
        }
        set
        {

            PlayerPrefs.SetInt("KeyTurnOffSound", value ? 1 : 0);
        }
    }
    public static bool turnOffVibrate
    {
        get
        {
            return PlayerPrefs.GetInt("KeyTurnOffVibrate", 1) == 1;
        }
        set
        {

            PlayerPrefs.SetInt("KeyTurnOffVibrate", value ? 1 : 0);
        }
    }
    #endregion
    public static int maxNumberHeroBattle
    {
        get
        {
            return PlayerPrefs.GetInt("KeyMaxNumberCardBattle", 3);
        }
        set
        {

            PlayerPrefs.SetInt("KeyMaxNumberCardBattle", value);
        }
    }
}
