using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(H==0?rb.velocity.x :H * Time.deltaTime *10 *speed, V == 0 ? rb.velocity.y : V * Time.deltaTime * 10*speed);
    }
}
