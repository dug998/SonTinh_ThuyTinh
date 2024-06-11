using UnityEngine;

public static class UserData
{
    public static int CurrentLevel
    {
        get { return PlayerPrefs.GetInt("key_current_level", 1); }
        set
        {
            PlayerPrefs.SetInt("key_current_level", value);
        }
    }
    public static int MaxLevelUnlock
    {
        get { return PlayerPrefs.GetInt("key_max_level_unlock", 1); }
        set
        {
            PlayerPrefs.SetInt("key_max_level_unlock", value);
        }
    }
    public static bool firstTimePlayGame
    {
        get { return PlayerPrefs.GetInt("key_first_time_play_game", 1) == 1; }
        set
        {
            PlayerPrefs.SetInt("key_first_time_play_game", value ? 1 : 0);
        }
    }

    #region Currency
    public static int GoldGame
    {
        get { return PlayerPrefs.GetInt("key_gold_game", 0); }
        set
        {
            PlayerPrefs.SetInt("key_gold_game", value);
            EventGame.UpdateCurrencyStatus?.Invoke();

        }
    }
    public static int GemGame
    {
        get { return PlayerPrefs.GetInt("key_gem_game", 0); }
        set
        {
            PlayerPrefs.SetInt("key_gem_game", value);
            EventGame.UpdateCurrencyStatus?.Invoke();
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
            return PlayerPrefs.GetInt("KeyMaxNumberCardBattle", 2);
        }
        set
        {

            PlayerPrefs.SetInt("KeyMaxNumberCardBattle", value);
        }
    }
    public static bool GetOwnHero(string key)
    {
        return PlayerPrefs.GetInt("key_own_" + key, 0) == 1;
    }
    public static void SetOwnHero(string key, bool values)
    {
        PlayerPrefs.SetInt("key_own_" + key, values ? 1 : 0);
    }
    public static int GetValuesStartHero(string key)
    {
        return PlayerPrefs.GetInt("key_start_" + key, 0);
    }
    public static void SetValuesStartHero(string key, int value)
    {
        PlayerPrefs.SetInt("key_start_" + key, value);
    }
    #endregion
}
