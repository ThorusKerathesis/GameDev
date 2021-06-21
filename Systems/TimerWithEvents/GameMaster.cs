using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private TimeController timeController;

    [SerializeField] private float tickCycle = 60f;
    [SerializeField] GameEvent _OnTick;

    private void Awake() => timeController = new TimeController(tickCycle);

    private void Start() => timeController.OnTick += HandleTick;

    private void Update() => timeController.Update();

    private void HandleTick(int number)
    {
        _OnTick?.Invoke();
    }
}
