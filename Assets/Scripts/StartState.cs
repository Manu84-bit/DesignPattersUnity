using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState :MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
        {
            _playerController = playerController;
           
        }
        _playerController.CurrentSpeed = _playerController.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //To keep moving the bike:
        if (_playerController)
        {
            if(_playerController.CurrentSpeed > 0)
            {
                _playerController.transform.Translate(
                    Vector3.forward * (_playerController.CurrentSpeed * Time.deltaTime)
                    );
            }
        }
    }
}
