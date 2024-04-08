using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    private Rigidbody playerRb;

    public bool ground = true;
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
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        ground = true;
    }
}
