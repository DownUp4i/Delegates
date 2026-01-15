using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private HeartTimerUI _heartTimerUI;
    [SerializeField] private TimerSliderUI _timerSliderUI;
    [SerializeField] private TimerTextUI _timerTextUI;

    public void Init(Timer timer)
    {
        _heartTimerUI.Init(timer);
        _timerSliderUI.Init(timer);
        _timerTextUI.Init(timer);
    }
}
