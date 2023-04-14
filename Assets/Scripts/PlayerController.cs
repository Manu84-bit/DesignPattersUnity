using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Controller: has responsibilities of controlling the bike's core components.
//It exists to offer an interface to control the bike,
//expose its configurable properties, and manage its structural dependencies.

public class PlayerController : MonoBehaviour
{
    public bool _showControls = false;
    //Player context that has access to player states and can modify them:
    private PlayerContext _playerContext;
    //Possible states of the player:
    private IPlayerState _stopState, _startState, _turnState;

    //Fields that characterize the player by default:
    public float maxSpeed = 2.0f;
    public float turnDistance = 2.0f;

    //Modifiable properties:
    public float CurrentSpeed
    {
        get; set;
    }

    public Direction CurrentTurnDirection
    {
        get;
        set;
    } 



    // Start is called before the first frame update
    void Start()
    {
        //Initlializing context and states
        _playerContext = new PlayerContext(this);

        //States are components of the playerController, so they extend MonoBehaviour and
        //implemente IState interface:
        _startState = gameObject.AddComponent<StartState>();
        _stopState = gameObject.AddComponent<StopState>();
        _turnState = gameObject.AddComponent<TurnState>();

        //Default state:
        _playerContext.Transition(_stopState);
    }


    //Methods to trigger states:

    public void StartPlayer()
    {
        _playerContext.Transition(_startState);
    } 
    
    public void StopPlayer()
    {
        _playerContext.Transition(_stopState);
    }
    
    public void TurnPlayer(Direction direction)
    {
        CurrentTurnDirection = direction;
        _playerContext.Transition(_turnState);
    }

    public enum Direction
    {
        RIGHT = 1, LEFT=-1
    }

    private void OnEnable()
    {
        GlobalEventBus.Subscribe(GlobalEventType.STARTED, EnableVehicle);
        GlobalEventBus.Subscribe(GlobalEventType.STOPPED, DisableVehicle);
    }

    private void OnDisable()
    {
        GlobalEventBus.UnSubscribe(GlobalEventType.STARTED, EnableVehicle);
        GlobalEventBus.UnSubscribe(GlobalEventType.STOPPED, DisableVehicle);
    }

    private void EnableVehicle()
    {
        _showControls = true;
        //CurrentSpeed = maxSpeed;
    }

    private void DisableVehicle()
    {
        _showControls = false;
        gameObject.transform.position = Vector3.zero;
        CurrentSpeed = 0;
    }
}
