using System.Collections.Generic;
using UnityEngine;

public class HeartTimerUI : MonoBehaviour
{
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private TimerHandler _timerHandler;

    private List<Heart> _hearts = new List<Heart>();

    private void Awake()
    {
        _timerHandler.SecondPassed += RemoveHeart;
        _timerHandler.Reseted += OnReset;
    }

    private void Start()
    {
        OnReset();
    }

    private void OnReset()
    {
        foreach (Heart heart in _hearts)
        {
            Destroy(heart.gameObject);
        }

        _hearts.Clear();


        for (int i = 0; i < _timerHandler.StartTime; i++)
        {
            _hearts.Add(Instantiate(_heartPrefab, transform));
        }
    }

    private void RemoveHeart()
    {
        int heartsQuantity = _hearts.Count;

        if (heartsQuantity > 0)
        {
            Destroy(_hearts[heartsQuantity - 1].gameObject);
            _hearts.RemoveAt(heartsQuantity - 1);
        }
    }

    private void OnDestroy()
    {
        _timerHandler.SecondPassed -= RemoveHeart;
        _timerHandler.Reseted -= OnReset;
    }
}
