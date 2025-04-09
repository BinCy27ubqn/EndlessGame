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

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private bool stopTouch = false;

    public float swipeRange;

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

        Swipe();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
            stopTouch = false;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !stopTouch)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (Distance.x < -swipeRange)
            {
                if (currentPos > 0)
                    currentPos--;

                stopTouch = true;
            }
            else if (Distance.x > swipeRange)
            {
                if (currentPos < 2)
                    currentPos++;

                stopTouch = true;
            }
            else if (Distance.y > swipeRange)
            {
                if (playerStateMachine.isGround)
                {
                    playerStateMachine.isJump = true;
                    stopTouch = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            playerStateMachine.isGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.isDead = true;
            GameManager.Instance.GameOver(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedUp"))
        {
            playerSpeed += 1;
            UIManager.instance.speedUp.SetActive(true);
            StartCoroutine(UIManager.instance.HideUIAfterDelay());
        }
    }
}
