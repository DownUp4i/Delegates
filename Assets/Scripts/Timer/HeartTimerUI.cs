using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HeartTimerUI : MonoBehaviour
{
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private Timer _timer;

    private int _seconds;
    private int _prevSecond = -1;

    private List<Heart> _hearts = new List<Heart>();

    public void Init(Timer timer)
    {
        _timer = timer;
        _timer.TimeLeft.Changed += DetermineSeconds;
        _timer.Reseted += OnReset;

        int seconds = Mathf.CeilToInt(_timer.StartTime);

        for (int i = 0; i < seconds; i++)
            _hearts.Add(Instantiate(_heartPrefab, transform));
    }

    private void OnReset()
    {
        int seconds = Mathf.CeilToInt(_timer.StartTime);

        if (_hearts.Count > 0)
            for (int i = 0; i < _hearts.Count; i++)
                Destroy(_hearts[i].gameObject);

        _hearts.Clear();

        for (int i = 0; i < seconds; i++)
            _hearts.Add(Instantiate(_heartPrefab, transform));
    }

    private void DetermineSeconds(float value) => RemoveHeart(Mathf.CeilToInt(value));

    private void RemoveHeart(int second)
    {
        if (_hearts.Count <= 0) return;

        if (second == _prevSecond) return;

        Destroy(_hearts[_hearts.Count - 1].gameObject);
        _hearts.RemoveAt(_hearts.Count - 1);

        _prevSecond = second;
    }

    private void OnDestroy()
    {
        _timer.TimeLeft.Changed -= DetermineSeconds;
    }
}
