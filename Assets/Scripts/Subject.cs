using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private readonly ArrayList _observers = new ArrayList();

    public void AttachedObserver(Observer observer)
    {
        _observers.Add(observer);
    }
    public void DettachedObserver(Observer observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyObservers()
    {
        foreach(Observer observer in _observers)
        {
            observer.GetNotified(this);
        }
    }
   
}
