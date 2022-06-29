using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    protected State currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }
    public virtual void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();

        //Debug.Log(currentState.stateName);
    }

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    protected virtual State GetInitialState()
    {
        return null;
    }
}
