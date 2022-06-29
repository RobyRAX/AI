using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : PlayerStateMachine
{
    public float walkSpeed;
    public float rollSpeed;
    public float rollDelay;

    public Animator animator;
    public Joystick joystick;

    //public Camera camera;

    public Idle idleState;
    public Roll rollState;
    public Walk walkState;

    protected override State GetInitialState()
    {
        return idleState;
    }

    private void Awake()
    {

        idleState = new Idle(this);
        rollState = new Roll(this);
        walkState = new Walk(this);

        joystick = joystick.gameObject.GetComponent<Joystick>();
    }

}
