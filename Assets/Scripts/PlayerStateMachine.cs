using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;

    private PlayerState currentState;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentState = new RunState();
        currentState.EnterState(this);
    }

    private void Update()
    {
        
    }

    public void ChangeState(PlayerState newState)
    {
        currentState = newState;
    }
}
