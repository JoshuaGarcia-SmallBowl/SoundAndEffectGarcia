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
    private Animator playerAnim;
    public bool guy;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        
        
            playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            ground = false;
            
            dbl = true;
            
            
                playerAnim.SetTrigger("Jump_trig");
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dbl)
        {
            playerRb.velocity = new(0,0,0);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dbl = false;
            if (guy)
            {
                playerAnim.SetTrigger("Jump_trig");
            }
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {

            gameOver = true;
            if (guy)
            {
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
            }
            else
            {
                playerAnim.SetFloat("Speed_f", 0);
                playerAnim.SetBool("Eat_b", true);
            }
                    

        }
        else
        {
            
            ground = true;
 
        }
 
    
    }
  
}
