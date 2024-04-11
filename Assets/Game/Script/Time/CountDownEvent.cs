using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class TimeRemaining
{
    public int days;
    public int hours;
    public int minutes;
    public int seconds;

    public TimeRemaining(int d, int h, int m, int s)
    {
        days = d;
        hours = h;
        minutes = m;
        seconds = s;
    }
   
    public TimeSpan TotalTimeSpan()
    {
        return new TimeSpan(days,hours, minutes, seconds);
    }
}
public class CountDownEvent : MonoBehaviour
{
    public string _keyCountDown;
    public TimeRemaining _timeRemaining;
    public TextMeshProUGUI _txtCountDown;
    public UnityEvent _eventEnd;
    public UnityEvent _eventStart;

    TimeSpan currentTime;
    DateTime TimeStart;
    DateTime TimeEnd;
    bool _eventRegistered = false;
    private void Awake()
    {
        LoadDateTime();
    }
    public void LoadDateTime()
    {
        TimeEnd = DateTimeManager.LoadTime(_keyCountDown);
        if (DateTime.Now >= TimeEnd)
        {
            StartTimer();
        }
        else
        {
            currentTime = TimeEnd - DateTime.Now;
        }
    }
    private void OnEnable()
    {
        if (!_eventRegistered)
        {
            EventGame.OnSecondsChanged += OnSecondsChanged;
            _eventRegistered = true;
        }
    }
    private void OnDisable()
    {
        if (_eventRegistered)
        {
            EventGame.OnSecondsChanged -= OnSecondsChanged;
            _eventRegistered = false;
        }
    }
    public void StartTimer()
    {
        TimeStart = DateTime.Now;
        TimeEnd = TimeStart.Add(_timeRemaining.TotalTimeSpan());
        currentTime = TimeEnd - DateTime.Now;
        DateTimeManager.SaveTime(_keyCountDown, TimeEnd);
        // đăng kí sự kiện
        if (!_eventRegistered)
        {
            EventGame.OnSecondsChanged += OnSecondsChanged;
            _eventRegistered = true;
        }
    }
    public void OnSecondsChanged()
    {
        if (currentTime.TotalSeconds > 0)
        {
            UpdateCountdownText();
            currentTime = currentTime.Subtract(TimeSpan.FromSeconds(1));
        }
        else
        {
            UpdateCountdownText();
            CountdownCompleted();
        }
    }
    public void CountdownCompleted()
    {
        LogGame.Log("Complete !!");
        _eventEnd.Invoke();
        // huy sự kiện
        if (_eventRegistered)
        {
            EventGame.OnSecondsChanged -= OnSecondsChanged;
            _eventRegistered = false;
        }
    }
    public void UpdateCountdownText()
    {
        string formattedTime;
        if (currentTime.Days > 0)
        {
            formattedTime = currentTime.ToString(@"d\d\ hh\h");
        }
        else if (currentTime.Hours > 0)
        {
            formattedTime = currentTime.ToString(@"hh\h\ mm\m");
        }
        else
        {
            formattedTime = currentTime.ToString(@"mm\m\ ss\s");
        }
        _txtCountDown.text = formattedTime;
    }
}
