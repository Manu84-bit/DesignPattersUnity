using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState :MonoBehaviour, IPlayerState
{
    private Vector3 _playerDirection;
    private PlayerController _playerController;
    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
        {
            _playerController = playerController;
           
        }
        _playerController.CurrentSpeed = _playerController.maxSpeed;

        _playerDirection.y = (float) _playerController.CurrentMoveDirection;
        _playerDirection.x = (float) _playerController.CurrentTurnDirection;
       

        //To keep moving the :
        if (_playerController)
        {
            if (_playerController.CurrentSpeed > 0)
            {
                _playerDirection = _playerDirection.normalized;
                _playerController.transform.Translate(
                    _playerDirection *
                    (_playerController.CurrentSpeed * Time.deltaTime)
                    );

       

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

      
        //_rotation = Quaternion.AngleAxis(_angle, Vector3.forward);

        //To keep moving the bike:
        //if (_playerController)
        //{
        //    if(_playerController.CurrentSpeed > 0)
        //    {
        //        _playerController.transform.Translate(
        //            _playerDirection *
        //            (_playerController.CurrentSpeed * Time.deltaTime)
        //            );

        //        //_playerController.transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, _rotationSpeed * Time.deltaTime);
        //    }
        //}
    }
}
