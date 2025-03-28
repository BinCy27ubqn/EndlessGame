using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerState
{
    public override void EnterState(PlayerStateMachine player)
    {
        player.animator.Play("Jump");
    }
}
