using UnityEngine;
using UnityEngine.UI;

public class TimerSliderUI : MonoBehaviour
{
    [SerializeField] private TimerHandler _timer;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        OnReset();

        _timer.SecondPassed += OnUpdateSlider;
        _timer.Reseted += OnReset;
    }

    private void OnDestroy()
    {
        _timer.SecondPassed -= OnUpdateSlider;
        _timer.Reseted -= OnReset;
    }

    private void OnUpdateSlider() => _slider.value = _timer.TimeLeft / _timer.StartTime;
    private void OnReset() => _slider.value = 1;
}
