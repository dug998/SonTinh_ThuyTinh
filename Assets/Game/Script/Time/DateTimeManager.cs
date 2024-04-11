using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTimeManager : MonoBehaviour
{
    public void Awake()
    {
        StartCoroutine(TimeLine());
    }
    IEnumerator TimeLine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            EventGame.OnSecondsChanged?.Invoke();
        }
    }
    #region Static
    public static int GetDaysInCurrentMonth(int month = -1)
    {
        // Lấy tháng và năm hiện tại
        if (month < 1)
        {
            month = DateTime.Now.Month;
        }
        int currentYear = DateTime.Now.Year;

        // Sử dụng hàm DaysInMonth để lấy số ngày trong tháng hiện tại
        return DateTime.DaysInMonth(currentYear, month);
    }
    public static void SaveTime(string key, DateTime time)
    {
        PlayerPrefs.SetString(key, time.ToString());
    }
    public static DateTime LoadTime(string key)
    {
        var timeAsString = PlayerPrefs.GetString(key, DateTime.Now.ToString());
        return DateTime.Parse(timeAsString);
    }
    #endregion

}
