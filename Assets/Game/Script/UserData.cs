using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    #region Setting
    public static float turnVolumeMusic
    {
        get
        {
            return PlayerPrefs.GetFloat("KeyTurnOffMusic", 1);
        }
        set
        {

            PlayerPrefs.GetFloat("KeyTurnOffMusic", value);
        }
    }
    public static float turnVolumeSound
    {
        get
        {
            return PlayerPrefs.GetFloat("KeyTurnOffSound", 0f);
        }
        set
        {

            PlayerPrefs.SetFloat("KeyTurnOffSound", value);
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
