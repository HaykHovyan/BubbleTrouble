using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class movement : MonoBehaviour
{

    private float speed = 10f;
    private float jump = 500f;
    private float Move;

    public Rigidbody2D rb;

    private bool IsJumping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move = UnityEngine.Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (UnityEngine.Input.GetButtonDown("Jump") && IsJumping == false) 
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump )); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJumping = true;
        }
    }
}
