using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//GameManager extends Singleton<T>. This way it becomes a singleton.
public class GameManager : Singleton<GameManager>
{
    private DateTime _sesionStartDateTime;
    private DateTime _sesionEndDateTime;
    // Start is called before the first frame update
    void Start()
    {
        // TODO:
        // - Load player save
        // - If no save, redirect player to registration scene
        // - Call backend and get daily challenge and rewards
        _sesionStartDateTime = DateTime.Now;
        Debug.Log("Game session start @: " + DateTime.Now);
    }

    void OnApplicationQuit()
    {
        _sesionEndDateTime = DateTime.Now;
        TimeSpan timeDifference = _sesionEndDateTime.Subtract(_sesionStartDateTime);

        Debug.Log("Game session ended @: " + DateTime.Now);
        Debug.Log("Game session lasted @: " + timeDifference);
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 120, 100, 100));
        if (GUILayout.Button("Next Scene"))
        {
          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        GUILayout.EndArea();
    }

}
