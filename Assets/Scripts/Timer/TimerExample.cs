using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private TimerUI _timerUIPrefab;
    private TimerUI _timerUI;

    [SerializeField] private float _startTime;

    private Timer _timer;
    private bool _isStarted;
    private bool _isInstance;

    public float StartTime => _startTime;
    public float TimeLeft => _timer.TimeLeft;

    private void Awake()
    {
        _isInstance = false;
        _isStarted = false;

        _timer = new Timer(_startTime, this);
        _timer.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (_isInstance == false)
            {
                _isInstance = true;
                _timerUI = Instantiate(_timerUIPrefab);
                _timerUI.Init(_timer);
            }
            else
            {
                _isInstance = false;
                Destroy(_timerUI.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
            _isStarted = !_isStarted;

        if (Input.GetKeyDown(KeyCode.R))
            _timer.Reset();

        if (_isStarted)
            _timer.Start();
        else
            _timer.Stop();
    }
}