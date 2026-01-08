using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    [SerializeField] private GameObject _timerUIPrefab;
    [SerializeField] private GameObject _walletUIPrefab;

    private bool _timerIsActive = false;
    private bool _walletIsActive = false;

    private void Awake()
    {
        _timerUIPrefab.gameObject.SetActive(_timerIsActive);
        _walletUIPrefab.gameObject.SetActive(_walletIsActive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _walletIsActive = true;
            _timerIsActive = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ; _timerIsActive = true;
            _walletIsActive = false;
        }

        _timerUIPrefab.gameObject.SetActive(_timerIsActive);
        _walletUIPrefab.gameObject.SetActive(_walletIsActive);
    }
}
