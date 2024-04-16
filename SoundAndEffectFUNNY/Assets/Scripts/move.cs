using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float speed = 5;
    public bool despawn;
    private PlayerController over;
    // Start is called before the first frame update
    void Start()
    {
        over = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (over.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if (despawn)
        {
            if (transform.position.x < -33)
            {
                Destroy(gameObject);
            }
        }
    }
}
