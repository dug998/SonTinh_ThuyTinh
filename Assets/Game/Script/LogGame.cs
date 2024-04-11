using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogGame
{
    private static bool _enableLog = true;

    public static bool EnableLog
    {
        get { return _enableLog; }
        set { _enableLog = value; }
    }

    public static void Log(object info, String color = "#35adcf")
    {
        if (EnableLog)
        {
            if (color != null)
            {
                Debug.Log(string.Format("<color={0}> {1} </color>", color, info));
            }
            else
            {
                Debug.Log(info);
            }
        }
    }
}
