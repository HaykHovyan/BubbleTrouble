using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform player;

    void Update()
    {
        int yPosition = ((int)player.position.y + 10) / 20 * 20;
        transform.position = new Vector3(0, yPosition, -10); 
    }
}
