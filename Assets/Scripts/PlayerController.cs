using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //animator
    [SerializeField]
    Animator anim;

    //Walking
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float stepInterval;
    [SerializeField]
    GameObject leftLeg;
    [SerializeField]
    GameObject rightLeg;
    Rigidbody2D leftLegRb;
    Rigidbody2D rightLegRb;

    //Jump
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float maxAirTime;
    [SerializeField]
    float groundCheckRadius;
    [SerializeField]
    LayerMask ground;
    [SerializeField]
    Transform groundCheck1;
    [SerializeField]
    Transform groundCheck2;
    [SerializeField]
    Rigidbody2D mainRb;
    bool isOnGround;
    bool isJumping;
    float timeInAir;

    void Start()
    {
        leftLegRb = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRb = rightLeg.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                anim.Play("WalkRight");
                StartCoroutine(MoveRight(stepInterval));
            }
            else
            {
                anim.Play("WalkLeft");
                StartCoroutine(MoveLeft(stepInterval));
            }
        }
        else
        {
            anim.Play("Idle");
        }

        isOnGround = Physics2D.OverlapCircle(groundCheck1.position, groundCheckRadius, ground);
        if (!isOnGround) isOnGround = Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, ground);
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
        if (isJumping && Input.GetKey(KeyCode.Space) && timeInAir <= maxAirTime)
        {
            mainRb.velocity = Vector2.up * jumpForce;
            timeInAir += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space) || timeInAir > maxAirTime)
        {
            isJumping = false;
            mainRb.velocity = Vector2.zero;
            timeInAir = 0;
        }
    }

    IEnumerator MoveRight(float seconds)
    {
        leftLegRb.AddForce(Vector2.right * moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightLegRb.AddForce(Vector2.right * moveSpeed * Time.deltaTime);
    }

    IEnumerator MoveLeft(float seconds)
    {
        rightLegRb.AddForce(Vector2.left * moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        leftLegRb.AddForce(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
