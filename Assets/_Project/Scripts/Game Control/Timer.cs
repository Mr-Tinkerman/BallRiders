using System;
using UnityEngine;

public class Timer
{
    public float startingTime { get; private set; }
    public float remainingTime { get; private set; }

    public event Action OnTimeDepleted = delegate { };

    private bool m_started = false;

    public Timer(float seconds)
    {
        startingTime = seconds;

        Reset();
    }

    ~Timer()
    {
        Stop();
    }

    private void _Tick(float dt)
    {
        // Timer countdown
        if (remainingTime > 0)
        {
            remainingTime = Mathf.Max(remainingTime - dt, 0);
        }
        else
        {
            OnTimeDepleted?.Invoke();
            Stop();
        }
    }

    public void AddTime(int seconds)
    {
        remainingTime += seconds;
    }

    public void RemoveTime(int seconds)
    {
        remainingTime -= seconds;
        remainingTime = Mathf.Max(remainingTime, 0);
    }

    public void Start()
    {
        Resume();
        Reset();
    }

    public void Stop()
    {
        Pause();
        Reset();
    }

    public void Resume()
    {
        if (!m_started)
            TimerController.OnTimerTick += _Tick;

        m_started = true;
    }

    public void Pause()
    {
        if (m_started)
            TimerController.OnTimerTick -= _Tick;

        m_started = false;
    }

    public void Reset()
    {
        remainingTime = startingTime;
    }
}