using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatbackground : MonoBehaviour
{
    private Vector3 possum;
    private float repwid;
    // Start is called before the first frame update
    void Start()
    {
        possum = transform.position;
        repwid = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < possum.x - repwid)
        {
            transform.position = possum;
        }
    }
}
