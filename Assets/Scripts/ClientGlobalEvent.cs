using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientGlobalEvent : MonoBehaviour
{
    private bool _countdownBtnEnabled;
    // Start is called before the first frame update
    void Start()
    {
        //Add the classes that contain the callbacks for each of the global events:
        gameObject.AddComponent<CountDownTimer>();
        //gameObject.AddComponent<PlayerController>();
        gameObject.AddComponent<HUDController>();
        //...

        _countdownBtnEnabled = true;

    }

    private void OnEnable()
    {
        GlobalEventBus.Subscribe(GlobalEventType.STOPPED, ReStart);
    }

    private void OnDisable()
    {
        GlobalEventBus.UnSubscribe(GlobalEventType.STOPPED, ReStart);
    }

    private void ReStart()
    {
        _countdownBtnEnabled = true;
    }

    private void OnGUI()
    {
        if (_countdownBtnEnabled)
        {
            GUILayout.BeginArea(new Rect(Screen.width/2 - 75, Screen.height/2, 150, 20));
            if (GUILayout.Button("Start Countdown"))
            {
                _countdownBtnEnabled = false;
                GlobalEventBus.Publish(GlobalEventType.COUNTDOWN);
            }
            GUILayout.EndArea();
        }
    }
}
