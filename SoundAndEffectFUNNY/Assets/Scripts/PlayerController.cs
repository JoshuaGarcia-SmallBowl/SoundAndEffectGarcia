using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public ParticleSystem expl;
    public ParticleSystem dirt;
    public AudioClip crash;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public bool dsp;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        
        
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
            dirt.Stop();

            if (guy)
            {
                playerAnim.SetTrigger("Jump_trig");
            }
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dbl)
        {
            playerRb.velocity = new(0,0,0);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dbl = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            if (guy)
            {
                playerAnim.SetTrigger("Jump_trig");
            }
        }

        if (ground && !gameOver)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                dsp = true;
                playerAnim.SetFloat("Speed_f", 1.0f);
            }
            else if (dsp)
            {
                dsp = false;
                playerAnim.SetFloat("Speed_f", 0.5f);
            }
        }
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            dirt.Stop(true);
            gameOver = true;
            
            if (guy)
            {
                expl.Play();
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                playerRb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
            }
            else
            {
                playerAnim.SetFloat("Speed_f", 0);
                playerAnim.SetBool("Eat_b", true);
            }
            playerAudio.PlayOneShot(crash, 1.0f);        

        }
        else
        {
            dirt.Play();
            ground = true;
 
        }
 
    
    }
  
}
