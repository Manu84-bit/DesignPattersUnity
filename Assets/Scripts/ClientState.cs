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
        _playerController = (PlayerController)FindObjectOfType(typeof(PlayerController));

    }

    private void Update()
    {
        float _verticalInput = Input.GetAxis("Vertical");
        float _horizontalInput = Input.GetAxis("Horizontal");
    

        if (_playerController.showControls)
        {
            if (_verticalInput > 0)
            {
                _playerController.StartPlayer(PlayerController.Direction.UP);
            }
            else if(_verticalInput < 0)
            {
                _playerController.StartPlayer(PlayerController.Direction.DOWN);
            }

            if (_horizontalInput > 0)
            {
                _playerController.TurnPlayer(PlayerController.Direction.RIGHT);
            }
            else if(_horizontalInput < 0)
            {
                _playerController.TurnPlayer(PlayerController.Direction.LEFT);
            }


        }
    }

    //private void OnGUI()
    //{
    //    if (_playerController._showControls)
    //    {
    //        //if (GUILayout.Button("Start player"))
    //        //{
    //        //    _playerController.StartPlayer();
    //        //}
    //        //if (GUILayout.Button("Stop Player"))
    //        //{
       
    //        //}
    //        //if (GUILayout.Button("Right"))
    //        //{
    //        //    _playerController.TurnPlayer(PlayerController.Direction.RIGHT);
    //        //}
    //        //if (GUILayout.Button("Left"))
    //        //{
    //        //    _playerController.TurnPlayer(PlayerController.Direction.LEFT);
    //        //}

    //    }


    //}

}



