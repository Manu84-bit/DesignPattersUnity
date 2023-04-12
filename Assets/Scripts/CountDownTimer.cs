using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    private readonly float _countDownTime = 4.0f;
    private float _currentTime;
    private bool _showCounter = false;
    void OnEnable()
    {
        GlobalEventBus.Subscribe(GlobalEventType.COUNTDOWN, StartTimer);
    }

    void OnDisable()
    {
        GlobalEventBus.UnSubscribe(GlobalEventType.COUNTDOWN, StartTimer);
    }

    private void StartTimer()
    {
        _showCounter = true;
        StartCoroutine(CountDown());
    }

    //Method to substract time:
    private IEnumerator CountDown()
    {
        _currentTime = _countDownTime;
        while(_currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }
        _showCounter = false;
        GlobalEventBus.Publish(GlobalEventType.STARTED);
    }

    private void OnGUI()
    {
        if (_showCounter)
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(Screen.width / 2 - 40 , Screen.height / 2, 80, 20), "Countdown: " + _currentTime);
        }
      
    }
}
