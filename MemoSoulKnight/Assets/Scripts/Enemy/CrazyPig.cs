using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyPig : Enemy 
{

    public override void Move()
    {
        GameObject go = GameObject.Find("Player");
        float x = go.transform.position.x;
        float y = go.transform.position.y;
        distance = Mathf.Sqrt((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x) + (player.transform.position.y - this.transform.position.y) * (player.transform.position.y - this.transform.position.y));
        {
            if (moveT > 0)
            {
                moveT -= Time.deltaTime;
                rb.velocity = (Quaternion.AngleAxis(moveD, new Vector3(0, 0, 1f)) * (new Vector2(1, 0))) * speed; ;
            }
            else
            {
                moveT = 1f;
                if (distance <= 1.5)
                {
                    rb.velocity = new Vector2(x - this.transform.position.x, y - this.transform.position.y) * speed;
                }
                else
                moveD = Random.Range(-180, 180);
            }
        }


    }



    float t;
    float tt;
    override public void Attack()
    {
      
        if(speed<0.5)speed = speed * 2;
        if (tt > 0)
        {
            tt -= Time.deltaTime;
        }
        else
        {
            GameObject go;
            go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Slash"));
            go.transform.position = this.transform.position;
            go.GetComponent<Slash>().canHurtE = false;
            go.GetComponent<Slash>().canHurtP = true;
            tt = 0.5f;
        }
        if (t > 0)
        {
            t -= Time.deltaTime;
        }
        else
        {
            CoolingTime = coolingTime;
            t = attackTime;
            CanAttack = false;
            speed = speed / 2;
        }

    }
    public override void Prepare()
    {
        distance = Mathf.Sqrt((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x) + (player.transform.position.y - this.transform.position.y) * (player.transform.position.y - this.transform.position.y));
        if(distance<=1.5)
        CanAttack = true;
    }
}
