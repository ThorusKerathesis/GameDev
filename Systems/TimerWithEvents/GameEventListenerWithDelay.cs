using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerWithDelay : GameEventListener
{
    [SerializeField] float _delay = 1f;
    [SerializeField] UnityEvent _delayedUnityEvent;

    private void Awake()
    {
        _gameEvent.Register(this);
    }
    private void OnDestroy()
    {
        _gameEvent.Deregister(this);
    }
    public override void RaiseEvent()
    {
        _unityEvent.Invoke();
        StartCoroutine(RunDelayedEvent());
    }
    private IEnumerator RunDelayedEvent()
    {
        yield return new WaitForSeconds(_delay);
        _delayedUnityEvent.Invoke();
    }
}
