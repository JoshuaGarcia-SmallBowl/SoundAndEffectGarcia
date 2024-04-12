using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanage : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] obstaclesMega;

    private float startDelay = 2;
    private float repeatRate = 2.5f;
    
    Vector3 goog;
    private bool on = true;
    private int count = 0;
    private int mega;
    public int megacap = 20;
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
        if (on)
        {
            mega = Random.Range(0, megacap);
            if (mega == 0) 
            {
                 int meg = Random.Range(0, obstaclesMega.Length);
                Instantiate(obstaclesMega[meg], new(30, 3.5f, -2), obstaclesMega[meg].transform.rotation);
                megacap = 20;
                count = 2;
                on = false;
            }
            else
            {
                int funny = Random.Range(0, obstacles.Length);
                if (funny >= 3)
                {
                    goog = new(Random.Range(28, 32), 3.5f, -2);
                    on = false;
                    count++;
                }
                else
                {
                    goog = new(Random.Range(26, 30), 0, 0);
                }
                Instantiate(obstacles[funny], goog, obstacles[funny].transform.rotation);
            }
           
        }
        else
        {
            count--;
            if (count == 0)
            {
                on = true; 
            }
        }
       
    }
}
