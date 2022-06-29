using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : State
{
    private PlayerManager _player;

    private float rollDelay;

    public Roll(PlayerManager player) : base("Roll", player)
    {
        _player = player;
    }

    public override void Enter()
    {
        _player.animator.SetBool("isRoll", true);
       

        rollDelay = _player.rollDelay;

        base.Enter();
    }

    public override void UpdateLogic()
    {
        if (rollDelay > 0)
        {
            _player.transform.Translate(0, 0, _player.rollSpeed * Time.deltaTime);
            //Debug.Log(rollDelay);
            rollDelay -= Time.deltaTime;
        }
        else
        {
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                _player.ChangeState(_player.walkState);
            else
                _player.ChangeState(_player.idleState);
        }

        base.UpdateLogic();
    }

    public override void Exit()
    {
        _player.animator.SetBool("isRoll", false);

        base.Exit();
    }

}
