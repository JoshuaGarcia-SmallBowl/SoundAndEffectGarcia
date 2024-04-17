using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCOunter : MonoBehaviour
{
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Point", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Point()
    {
        score++;
        Debug.Log(score);
    }
}
