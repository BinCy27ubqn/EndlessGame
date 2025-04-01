using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerState
{
    public override void EnterState(PlayerStateMachine player)
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.isGround)
        {
            player.rb.velocity = Vector3.up * player.jumpForce;
            player.animator.Play("Jump");
            player.isGround = false;
        }
    }

}
