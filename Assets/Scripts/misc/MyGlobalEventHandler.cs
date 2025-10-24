using System;

using UnityEngine;

public class MyGlobalEventHandler : Singleton<MyGlobalEventHandler>
{
    public static new MyGlobalEventHandler instance => Singleton<MyGlobalEventHandler>.instance;

    public delegate void StompEvent(Vector3 transform);
    public delegate void CitisenDiedEvent();

    public event StompEvent OnStomp;
    public event CitisenDiedEvent OnCitisenDied;

    public Action OnPostStomp;
    public void InvokeStompEvent(Vector3 transform)
    { 
        OnStomp?.Invoke(transform);
    }

    public void InvokeCitisenDiedEvent()
    {
        OnCitisenDied?.Invoke();
    }
    public void InvokePostStomp()
    { 
        OnPostStomp?.Invoke();
    }
}
