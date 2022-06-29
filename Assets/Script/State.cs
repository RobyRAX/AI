using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public string stateName;
    protected PlayerStateMachine stateMachine;

    public State(string stateName, PlayerStateMachine stateMachine)
    {
        this.stateName = stateName;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
}
