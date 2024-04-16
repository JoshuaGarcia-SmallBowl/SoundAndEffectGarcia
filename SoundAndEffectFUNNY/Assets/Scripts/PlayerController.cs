using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    private Rigidbody playerRb;

    public bool ground = true;
    private bool dbl = true;
    public bool gameOver = false;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            ground = false;
            
            dbl = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dbl)
        {
            playerRb.velocity = new(0,0,0);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dbl = false;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {

            gameOver = true;

        }
        else
        {
            
            ground = true;
 
        }
 
    
    }
  
}
