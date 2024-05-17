using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public static class UserData
{
    #region Currency
    public static int GoldGame
    {
        get { return PlayerPrefs.GetInt("key_gold_game", 0); }
        set
        {
            PlayerPrefs.SetInt("key_gold_game", value);
            EventGame.UpdateCurrencyStatus.Invoke();

        }
    }
    public static int GemGame
    {
        get { return PlayerPrefs.GetInt("key_gem_game", 0); }
        set
        {
            PlayerPrefs.SetInt("key_gem_game", value);
            EventGame.UpdateCurrencyStatus.Invoke();
        }
    }
    public static int EnergyGame
    {
        get { return PlayerPrefs.GetInt("key_energy_game", 0); }
        set
        {
            PlayerPrefs.SetInt("key_energy_game", value);
            EventGame.UpdateCurrencyStatus.Invoke();
        }
    }
    #endregion
    #region Setting
    public static float turnVolumeMusic
    {
        get
        {
            return PlayerPrefs.GetFloat("key_turn_music", 1);
        }
        set
        {

            PlayerPrefs.GetFloat("key_turn_music", value);
        }
    }
    public static float turnVolumeSound
    {
        get
        {
            return PlayerPrefs.GetFloat("Key_turn_sound", 0f);
        }
        set
        {

            PlayerPrefs.SetFloat("Key_turn_sound", value);
        }
    }
    public static bool turnOffVibrate
    {
        get
        {
            return PlayerPrefs.GetInt("key_turn_off_vibrate", 1) == 1;
        }
        set
        {

            PlayerPrefs.SetInt("key_turn_off_vibrate", value ? 1 : 0);
        }
    }
    #endregion
    #region Daily
    /// <summary>
    /// Daily Prize Position
    /// </summary>
    public static int DailyPrizePosition
    {
        get { return PlayerPrefs.GetInt("DailyPrizePosition", 0); }
        set
        {
            PlayerPrefs.SetInt("DailyPrizePosition", value);
        }
    }
    /// <summary>
    /// Received prize today
    /// </summary>
    public static bool ReceivedDailyPrize
    {
        get { return PlayerPrefs.GetInt("ReceivedDailyPrize", 0) == 1; }
        set
        {
            PlayerPrefs.SetInt("ReceivedDailyPrize", value ? 1 : 0);
        }
    }
    #endregion
    #region Hero
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
    public static int GetValuesStartHero(string key)
    {
        return PlayerPrefs.GetInt(key, 0);
    }
    public static void SetValuesStartHero(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    #endregion
}
