using System;
using UnityEngine;

public class TimeController
{
    public event Action<int> OnTick;

    private float tickTimer;
    private float currentTimer = 0f;

    public TimeController(float tickCycle)=> tickTimer = tickCycle;

    public void Update() => UpdateTime();

    private void UpdateTime()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer >= tickTimer)
        {
            currentTimer = 0f;
            OnTick?.Invoke(1);   
        }
    }
}
