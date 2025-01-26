using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]
    float damageForce;
    Rigidbody2D mainRb;

    void Start()
    {
        mainRb = GetComponent<Rigidbody2D>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        else
        {
            mainRb.AddForce((transform.position - collision.transform.position).normalized * damageForce);
        }
    }
}
