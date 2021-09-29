using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float vel = 10;
    private float speed = 0;
    public float jumpSpeed = 10;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }
    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, Vector3.down);
        speed = 0;
        RaycastHit collide;
        if (Physics.Raycast(r, out collide, 1))
        {
            if(collide.transform != null)
            {
                if (Input.GetKey(KeyCode.Space))
                    Jump();
            }
        }
        Movement();
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
    }

    public float GetSpeed()
    {
        return speed;
    }

    void Movement()
    {  
        if (Input.GetKey(KeyCode.UpArrow))
            speed -= vel;
        else if (Input.GetKey(KeyCode.DownArrow))
            speed += vel;
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.transform.Rotate(0, -0.5f, 0);
        else if (Input.GetKey(KeyCode.RightArrow))
            rb.transform.Rotate(0, 0.5f, 0);
    }
}
