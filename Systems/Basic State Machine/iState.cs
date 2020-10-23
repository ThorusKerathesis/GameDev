using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iState
{
    void Tick();
    void OnEnter();
    void OnExit();
}
