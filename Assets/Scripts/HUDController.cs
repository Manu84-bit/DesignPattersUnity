using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private bool _showStopBtn;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GlobalEventBus.Subscribe(GlobalEventType.STARTED, ShowStopButton);
    }
    private void OnDisable()
    {
        GlobalEventBus.UnSubscribe(GlobalEventType.STARTED, ShowStopButton);
    }

    private void OnGUI()
    {
        if (_showStopBtn)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 75, 0, 150, 20));
            if (GUILayout.Button("Stop race"))
            {
                _showStopBtn = false;
                GlobalEventBus.Publish(GlobalEventType.STOPPED);
            }
            GUILayout.EndArea();
        }
    }

    private void ShowStopButton()
    {
        _showStopBtn = true;
    }
}
