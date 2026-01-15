using UnityEngine;
using UnityEngine.UI;

public class TimerSliderUI : MonoBehaviour
{
    private Timer _timer;
    [SerializeField] private Slider _slider;

    public void Init(Timer timer)
    {
        _timer = timer;
        _timer.TimeChanged += OnUpdateSlider;
    }

    private void OnDestroy()
    {
        _timer.TimeChanged -= OnUpdateSlider;
    }

    private void OnUpdateSlider(float value) => _slider.value = value / _timer.StartTime;
}
