using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerStateMachine Instance;

    public bool isJump = false;

    public bool isGround;
    public float jumpForce;

    public Animator animator;
    public Rigidbody rb;
    public Transform checkPosition;
    
    private PlayerState currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isGround = true;
    }

    private void Update()
    {
        if (isGround && GameManager.Instance.startGame)
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
