using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventBus 
{
    //Dictionary to store events asociated with a Global game event label:
    private static readonly IDictionary<GlobalEventType, UnityEvent> Events =
        new Dictionary<GlobalEventType, UnityEvent>();

    //Method to assign a callback o listener to a global event:
    public static void Subscribe(GlobalEventType eventType, UnityAction callback)
    {
        //UnityEvent thisEvent;
        if(Events.TryGetValue(eventType,  out UnityEvent thisEvent))
        {
            thisEvent.AddListener(callback);
        } else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(callback);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void UnSubscribe(GlobalEventType eventType, UnityAction callback)
    {
        //UnityEvent thisEvent;
        if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
        {
            thisEvent.RemoveListener(callback);
        }
    }

    public static void Publish(GlobalEventType eventType)
    {
        //UnityEvent thisEvent;
        if(Events.TryGetValue(eventType, out UnityEvent thisEvent)){
            thisEvent.Invoke();
        }
    }

}
