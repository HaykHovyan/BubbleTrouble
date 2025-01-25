using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]
    float damageForce;
    [SerializeField]
    Rigidbody2D torsoRb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("eli vat chi");
        if (collision.gameObject.tag == "Player")
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        if (collision.gameObject.tag == "Spike")
        {
            Debug.Log("aaaaaaaaaaaa");
            Vector2 directionFromSpike = (transform.position - collision.transform.position).normalized;
            torsoRb.AddForce(directionFromSpike * damageForce);
        }
    }
}
