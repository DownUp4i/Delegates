using System;
using UnityEngine;

public class Timer
{
    private float _startTime;
    private bool _isRunning;

    private float _timeLeft;
    public float TimeLeft => _timeLeft;

    public Timer(float startTime)
    {
        _startTime = startTime;
        _timeLeft = _startTime;
    }

    public void Start()
    {
        _isRunning = true;
    }

    public void Stop()
    {
        _isRunning = false;
    }

    public void Reset()
    {
        _timeLeft = _startTime;
    }

    public void Update()
    {
        if (!_isRunning)
            return;

        _timeLeft -= Time.deltaTime;

        if(_timeLeft < 0 )
            _timeLeft = 0;
    }
}
