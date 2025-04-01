using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform centerPos;
    public Transform leftPos;
    public Transform rightPos;

    int currentPos = 1;
    public float speedSwipe;

    public float playerSpeed;

    private Rigidbody rb;

    public PlayerStateMachine playerStateMachine;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);

        if (currentPos == 1)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                currentPos = 0;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                currentPos = 2;
            }
        }

        if (currentPos == 0 && Input.GetKeyDown(KeyCode.D))
        {
            currentPos = 1;
        }

        if (currentPos == 2 && Input.GetKeyDown(KeyCode.A))
        {
            currentPos = 1;
        }

        if (currentPos == 0)
        {
            if(Vector3.Distance(transform.position,new Vector3(leftPos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                Vector3 dir = new Vector3(leftPos.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(dir * speedSwipe * Time.deltaTime);
            }
        }
        else if (currentPos == 1)
        {
            if (Vector3.Distance(transform.position, new Vector3(centerPos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                Vector3 dir = new Vector3(centerPos.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(dir * speedSwipe * Time.deltaTime);
            }
        }
        else if (currentPos == 2)
        {
            if (Vector3.Distance(transform.position, new Vector3(rightPos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                Vector3 dir = new Vector3(rightPos.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(dir * speedSwipe * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            playerStateMachine.isGround = true;
        }
    }
}
