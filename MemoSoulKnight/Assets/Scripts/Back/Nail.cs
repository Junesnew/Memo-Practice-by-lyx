using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour
{
    public bool nail;
    public Animator anim;
    public float nailTime = 1.0f;
    public float noNailTime = 2.0f;
    public float i,j;//计时器
    public float hit;
    // Start is called before the first frame update
    void Start()
    {
        nail = false;
        i = noNailTime;
        anim.SetBool("Nail", false);
        j = 0;
        hit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (nail)
        {
            j -= Time.deltaTime;
            if (j <= 0) { hit = 0; nail = false;i = noNailTime;anim.SetBool("Nail", false); }
        }
        else
        {
            i -= Time.deltaTime;
            if (i <= 0) { nail = true;j = nailTime; anim.SetBool("Nail", true); }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(nail)
        {
            if (hit <= 0)
            {
                if (collision.tag == "Player")
                    collision.GetComponent<Player>().damage = 1;
                if (collision.tag == "Enemy")
                    collision.GetComponent<EnemyPara>().damage = 2;
                hit = 1;
            }
            else
            {
                hit -= Time.deltaTime;
            }
           
        }
    }
}
