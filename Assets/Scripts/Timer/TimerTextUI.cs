using System;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TimerTextUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    private Timer _timer;

    public void Init(Timer timer)
    {
        _timer = timer;
        _timer.TimeLeft.Changed += DetermineSeconds;
        _timerText.text = timer.StartTime.ToString("00:00");
    }

    private void OnDestroy()
    {
        _timer.TimeLeft.Changed -= DetermineSeconds;
    }

    private void DetermineSeconds(float value)
    {
        if (value <= 0)
            value = 0;
        OnTextChange(Mathf.FloorToInt(value));
    }

    private void OnTextChange(int value) => _timerText.text = value.ToString("00:00");
}
