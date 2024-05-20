using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventGame
{
    public static Action<int> changeCoin;
    public static Action UpdateCurrencyStatus;

    #region Time
    
    public static Action OnSecondsChanged;
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    #endregion
    public static Action<bool> OnNotifyQuest;
    public static Action<bool> OnNotifyDaily;

    public static Action <bool> OnNotifyWeather;
}
