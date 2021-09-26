using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float vel = 5;
    public float jumpSpeed = 10;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, Vector3.down);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float speed = vel;
        

        RaycastHit collide;
        if (Physics.Raycast(r, out collide, 1))
        {
            if(collide.transform != null)
            {
                if (Input.GetKey(KeyCode.Space))
                    Jump();
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
            speed = speed * 3;
        rb.velocity = new Vector3(-h * speed,rb.velocity.y,-v * speed);

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
    }
}
