using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContext
{

    private readonly PlayerController _playerController;

    public IPlayerState CurrentPlayerState
    {
        get; set;
    }

    public PlayerContext(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public void Transition()
    {
        CurrentPlayerState.Handle(_playerController);
    }

    public void Transition(IPlayerState state)
    {
        CurrentPlayerState = state;
        CurrentPlayerState.Handle(_playerController);
    }
}
