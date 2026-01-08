using TMPro;
using UnityEngine;

public class TimerTextUI : MonoBehaviour
{
    [SerializeField] private TimerHandler _timer;
    [SerializeField] private TMP_Text _timerText;

    private void Update()
    {
        int timer = Mathf.CeilToInt(_timer.TimeLeft);

        _timerText.text = timer.ToString("00");
    }
}
