using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour   //控制wasd移动与转向，刚体移动
{
    public Rigidbody2D rb;
    public float speed = 6f;
    public float face = 0f;
    public float speederTime;
    public float deltaSpeed;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        speederTime = 0f;
        deltaSpeed = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!this.GetComponent<Player>().death)
        {
            if (speederTime > 0)
            {
                speed = 6 + deltaSpeed;
                speederTime -= Time.deltaTime;
            }
            else { speed = 6f; }
            float face = Input.GetAxisRaw("Horizontal");
            if (face != 0) this.transform.localScale = new Vector3(face, 1, 1);
            float H = Input.GetAxis("Horizontal");
            float V = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(H == 0 ? rb.velocity.x : H * Time.deltaTime * 10 * speed, V == 0 ? rb.velocity.y : V * Time.deltaTime * 10 * speed);
            if (H == 0 && V == 0)
            {
                anim.SetBool("isStand", true);

            }
            else { anim.SetBool("isStand", false); }
        }
    }
}
