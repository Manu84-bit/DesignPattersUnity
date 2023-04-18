using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    private Vector3 _turnDirection;

    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
        {
            _playerController = playerController;
        }

        _turnDirection.x = (float) _playerController.CurrentTurnDirection;

        if(_playerController.CurrentSpeed > 0)
        {
            _playerController.transform.Translate(
                _playerController.turnDistance * Time.deltaTime * _turnDirection
                );
        }

    }

   
}
