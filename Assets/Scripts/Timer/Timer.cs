using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private MonoBehaviour _coroutineRunner;
    private Coroutine _coroutine;

    private ReactiveVariable<float> _timeLeft;

    public event Action Reseted;

    private bool _isRunning;

    private float _startTime;

    public Timer(float startTime, MonoBehaviour coroutineRunner)
    {
        _startTime = startTime;
        _coroutineRunner = coroutineRunner;

        _timeLeft = new ReactiveVariable<float>(_startTime);
    }

    public float StartTime => _startTime;
    public ReactiveVariable<float> TimeLeft => _timeLeft;

    public void Start()
    {
        _isRunning = true;

        if (_coroutine != null)
            _coroutineRunner.StopCoroutine(_coroutine);

        _coroutine = _coroutineRunner.StartCoroutine(UpdateTimer());
    }

    public void Stop() => _isRunning = false;

    public void Reset()
    {
        _timeLeft.Value = _startTime;
        Reseted?.Invoke();
    }

    private IEnumerator UpdateTimer()
    {
        while (_isRunning && _timeLeft.Value > 0)
        {
            _timeLeft.Value -= Time.deltaTime;
            yield return null;
        }

        _isRunning = false;
        _coroutine = null;

        yield return null;
    }
}
