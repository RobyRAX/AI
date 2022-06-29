using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
    private PlayerManager _player;

    public Walk(PlayerManager player) : base("Walk", player)
    {
        _player = player;
    }

    public override void Enter()
    {
        _player.animator.SetBool("isWalk", true);

        base.Enter();
    }

    public override void UpdateLogic()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.ChangeState(_player.rollState);
        }

        if (_player.joystick.Horizontal == 0 && _player.joystick.Vertical == 0)
        {
            _player.ChangeState(_player.idleState);
        }

        Move();

        base.UpdateLogic();
    }

    public override void Exit()
    {
        _player.animator.SetBool("isWalk", false);

        base.Exit();
    }

    void Move()
    {
        /*var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");*/

        var x = _player.joystick.Horizontal;
        var y = _player.joystick.Vertical;

        Vector3 eu = Camera.main.transform.rotation.eulerAngles;
        float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
        Quaternion walkDir;

        if (Camera.main.GetComponent<ThirdPersonCamera>().mThirdPersonCameraType == ThirdPersonCamera.ThirdPersonCameraType.Follow_IndependentRotation)
            walkDir = Quaternion.Euler(new Vector3(0, angle + eu.y + 180, 0));
        else
            walkDir = Quaternion.Euler(new Vector3(0, angle, 0));

        Debug.Log(angle + " & " + eu + " = " + walkDir);

        if (x != 0 || y != 0)
        {
            _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, walkDir, 0.5f);
            _player.transform.Translate(Vector3.forward * _player.walkSpeed * Time.deltaTime);
        }          
    }
}
