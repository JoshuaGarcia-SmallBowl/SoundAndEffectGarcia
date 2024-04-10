using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanage : MonoBehaviour
{
    public GameObject[] obstacles;
    

    private float startDelay = 2;
    private float repeatRate = 2f;
    int off = 0;
    Vector3 goog;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        
        int funny = Random.Range(0, obstacles.Length);
        if (funny >= 3)
        {
            goog = new(Random.Range(25 + off, 29 + off), 3.5f, -2);
            off += 12;
        }
        else
        {
            goog = new(Random.Range(23 + off, 27 + off), 0, 0);
        }
        Instantiate(obstacles[funny], goog, obstacles[funny].transform.rotation);
    }
}
