using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Idle : State
{
    private PlayerManager _player;

    public Idle(PlayerManager player) : base("Idle", player)
    {
        _player = player;
    }

    public override void Enter()
    {              
        
        _player.animator.SetBool("isIdle", true);

        base.Enter();
    }

    
    public override void UpdateLogic()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.ChangeState(_player.rollState);
        }

        if (_player.joystick.Horizontal != 0 || _player.joystick.Vertical != 0)
        {
            stateMachine.ChangeState(_player.walkState);
        }

        base.UpdateLogic();
    }

    public override void Exit()
    {
        _player.animator.SetBool("isIdle", false);

        base.Exit();
    }

    
}
