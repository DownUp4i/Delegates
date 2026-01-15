using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private MonoBehaviour _coroutineRunner;
    private Coroutine _coroutine;

    public event Action<float> TimeChanged;
    public event Action Reseted;

    private bool _isRunning;

    private float _startTime;
    private float _timeLeft;

    public float TimeLeft => _timeLeft;
    public float StartTime => _startTime;

    public Timer(float startTime, MonoBehaviour coroutineRunner)
    {
        _startTime = startTime;
        _timeLeft = _startTime;
        _coroutineRunner = coroutineRunner;
    }

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
        _timeLeft = _startTime;
        Reseted?.Invoke();
    }

    private IEnumerator UpdateTimer()
    {
        while (_isRunning && _timeLeft > 0)
        {
            TimeChanged?.Invoke(_timeLeft);
            _timeLeft -= Time.deltaTime;
            yield return null;
        }

        _isRunning = false;
        _coroutine = null;

        yield return null;
    }
}
