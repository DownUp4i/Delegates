using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] private float _startTime;
    private float _accumulator;

    private Timer _timer;
    private bool _isStarted;

    public event Action SecondPassed;
    public event Action Reseted;

    public float StartTime => _startTime;
    public float TimeLeft => _timer.TimeLeft;

    private void Awake()
    {
        _timer = new Timer(_startTime);
        _isStarted = false;
        _timer.Stop();
    }

    private void Update()
    {
        _timer.Update();

        if (Input.GetKeyDown(KeyCode.Space))
            _isStarted = !_isStarted;

        if (Input.GetKeyDown(KeyCode.R))
        {
            _timer.Reset();
            Reseted?.Invoke();
        }

        if (_isStarted)
        {
            CheckSecondLeft();
            _timer.Start();
        }
        else
        {
            _timer.Stop();
        }
    }

    private void CheckSecondLeft()
    {
        _accumulator += Time.deltaTime;

        if (_accumulator > 1)
        {
            SecondPassed?.Invoke();
            _accumulator -= 1;
        }
    }
}