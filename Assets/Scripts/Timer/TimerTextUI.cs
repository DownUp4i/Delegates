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
        _timer.TimeChanged += DetermineSeconds;
        _timerText.text = timer.StartTime.ToString("00:00");
    }

    private void DetermineSeconds(float value) => OnTextChange(Mathf.FloorToInt(value));

    private void OnTextChange(int value) => _timerText.text = value.ToString("00:00");
}
