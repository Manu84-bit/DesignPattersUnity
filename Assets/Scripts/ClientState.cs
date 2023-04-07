using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Client to trigger sates on GUI:
public class ClientState : MonoBehaviour
{

    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = (PlayerController) FindObjectOfType(typeof(PlayerController));

    }

    private void OnGUI()
    {
        if(GUILayout.Button("Start player"))
        {
            _playerController.StartPlayer();
        } 
        if(GUILayout.Button("Stop Player"))
        {
            _playerController.StopPlayer();
        }
        if (GUILayout.Button("Right"))
        {
            _playerController.TurnPlayer(PlayerController.Direction.RIGHT);
        }
        if (GUILayout.Button("Left"))
        {
            _playerController.TurnPlayer(PlayerController.Direction.LEFT);
        }

    }
}
