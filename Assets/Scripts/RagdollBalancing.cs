using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBalancing : MonoBehaviour
{
    [SerializeField]
    float targetRotation;
    [SerializeField]
    float force;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.deltaTime));
    }
}
