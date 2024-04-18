using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCOunter : MonoBehaviour
{
    private int score;
    private PlayerController over;
    // Start is called before the first frame update
    void Start()
    {
        over = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("Point", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Point()
    {
        if(!over.gameOver)
        {
            if (over.dsp)
            {
                score += 2;
                
            }
            else
            {
                score++;
            }
            Debug.Log(score);
        }
       
    }
}
