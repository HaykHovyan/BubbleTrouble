using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static Camera camera;

    void Start()
    {
        camera = Camera.main;   
    }

    public static void CameraUp()
    {
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 20, camera.transform.position.z); 
    }
    public static void CameraDown()
    {
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 20, camera.transform.position.z);
    }
}
