using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public bool isGround;
    public float jumpForce;

    public Animator animator;
    public Rigidbody rb;
    public Transform checkPosition;
    
    private PlayerState currentState;

    private void Start()
    {
        isGround = true;
        ChangeState(new RunState());
    }

    private void Update()
    {
        if (isGround)
        {
            if (currentState is RunState)
            {
                ChangeState(new RunState());
            }
            ChangeState(new JumpState());
        }
    }

    public void ChangeState(PlayerState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

}
