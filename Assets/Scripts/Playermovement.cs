using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce=500f, forwardForceTemp, rightLeftForce=500f, jumpForce=100f;
    public bool jump,isForwardForce=true;
    
    // Start is called before the first frame update
    void Start()
    {
        forwardForceTemp = forwardForce;
    }

    // FixedUpdate is called once per frame and used here because we are interacting with Unity's physics system
    //and thiss method makes collisions smoother

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Ground")
        {
            jump = true;
            rb.mass = 1;
            forwardForce = forwardForceTemp;
        }
    }

    void FixedUpdate()
    {
        if (isForwardForce == true)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime); //add force of 2000 on the z axis
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(rightLeftForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-rightLeftForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (jump == true)
            {
                rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                rb.mass = 3;
                forwardForce = forwardForce * 3;
                jump = false;
            }
        }

        if(rb.position.y < 0f)
        {
            isForwardForce = false;
            rb.AddForce(0, 0, 0);
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
