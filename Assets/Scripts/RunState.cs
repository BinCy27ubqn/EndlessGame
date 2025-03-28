using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerState
{
    public override void EnterState(PlayerStateMachine player)
    {
        Debug.Log("a");
        player.animator.Play("run");
    }
}
