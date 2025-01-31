using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    //public Transform floor;
    public List<Transform> a;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(enemy,floor.position,new Quaternion());
        foreach (var i in a)
        {
            Instantiate(enemy, i.position, new Quaternion());
        }
    }
}
