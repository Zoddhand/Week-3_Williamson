using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Scroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float scroll = 0.0f;
    public float scroll_Speed = 0.1f;
    void FixedUpdate()
    {
        scroll += 0.1f;
        float scroll_Pos = scroll + transform.position.x;
        transform.position = new Vector3(scroll_Pos, transform.position.y, transform.position.z);

        if(transform.position.x >= 1000)
            transform.position = new Vector3(0, transform.position.y, transform.position.z); scroll = 0.0f;
    }
}
