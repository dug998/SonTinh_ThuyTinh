using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyGameManager : MonoBehaviour
{

    public string keyDailyMonth = "KeyLastLoginTime";
    public static int DailyPrizePosition
    {
        get { return UserData.DailyPrizePosition; }
        set { UserData.DailyPrizePosition = value; }
    }
    public static bool ReceivedDailyPrize
    {
        get { return UserData.ReceivedDailyPrize; }
        set
        {
            EventGame.OnNotifyDaily?.Invoke(!value);
            UserData.ReceivedDailyPrize = value;
        }
    }
    public static bool HasOneDay;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        OnGame();
    }
    public void OnGame()
    {
        bool HasOneDay = HasOneDayPassed();
        if (HasOneDay)
        {

            ReceivedDailyPrize = false;
            DailyPrizePosition += 1;
        }
    }
    public bool HasOneDayPassed()
    {
        if (!PlayerPrefs.HasKey(keyDailyMonth))
        {
            DateTimeManager.SaveTime(keyDailyMonth, DateTime.Now);
            return true;
        }
        if ((DateTime.Now - DateTimeManager.LoadTime(keyDailyMonth)).TotalMinutes >= 10)
        {
            DateTimeManager.SaveTime(keyDailyMonth, DateTime.Now);
            return true;
        }
        return false;
    }
}
