using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    //这是怪物的移动动画
    // Start is called before the first frame update
    public float face=0.0f;
    public bool isDeath = false;
    public bool isStand = true;
    public float a, b;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeath)//没死的话，永远面朝玩家
        {
            if ((this.name != "GoldOre") && (this.name != "EnergyOre"))//矿石不能转头
            {
                a = GameObject.Find("Player").transform.position.x;
                b = this.transform.position.x;
                face = ((GameObject.Find("Player").transform.position.x - this.transform.position.x) >= 0 ? 1 : -1);
                this.transform.localScale = new Vector3(face, 1, 1);
            }
        }
        if(isDeath)//根据状态切换动画
        {
            this.gameObject.GetComponent<Animator>().SetBool("isDeath", true); 
        }
        if(isStand)
        {
            this.gameObject.GetComponent<Animator>().SetBool("isStand", true);

        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetBool("isStand", false);
        }

    }
}
