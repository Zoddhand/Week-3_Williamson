using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float vel = 10;
    private float speed = 0;
    private bool isJump = false;
    public float jumpSpeed = 10;
    public float turnSpeed = 1.0f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self); // update our position each frame. 
        Ray r = new Ray(transform.position, Vector3.down); // make a ray from the bottom of our player.
        Debug.DrawRay(transform.position,Vector3.down,Color.magenta);
        RaycastHit collide;
        
        if (Physics.Raycast(r, out collide, 1)) // if the ray hits something
        {
            if (collide.transform != null) 
            {
                isJump = false; // let us jump.
                if (Input.GetKey(KeyCode.Space))
                {
                    Jump();
                    isJump = true;
                } 
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        speed = 0;
        Movement();

        if (transform.position.y <= -5.0f)
        {
            GameManager.instance.pLive = false;
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
    }

    public float GetSpeed()
    {
        return speed;
    }
    public bool GetJump()
    {
        return isJump;
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            speed -= vel;
        else if (Input.GetKey(KeyCode.DownArrow))
            speed += vel;
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.transform.Rotate(0, -turnSpeed, 0);
        else if (Input.GetKey(KeyCode.RightArrow))
            rb.transform.Rotate(0, turnSpeed, 0);
    }
}
