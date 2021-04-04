using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Enemy 
{
    public override  void Move()
    {
        GameObject go = GameObject.Find("Player");
        float x = go.transform.position.x;
        float y = go.transform.position.y;
        distance = Mathf.Sqrt((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x) + (player.transform.position.y - this.transform.position.y) * (player.transform.position.y - this.transform.position.y));
        if (distance <= 1.5)
        {
            rb.velocity = new Vector2(x - this.transform.position.x, y - this.transform.position.y) * speed;
        }
        else
        {
            if (moveT  >0)
            {
                moveT -= Time.deltaTime;
                rb.velocity = (Quaternion.AngleAxis(moveD, new Vector3(0, 0, 1f)) * (new Vector2(1, 0))) * speed; ;
            }
            else
            {
                moveT = 1f;
                moveD = Random.Range(-180, 180);
            }
        }


    }
    override public void Attack()
    {
        GameObject go;
        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Slash"));
        go.transform.position =this.transform . position;
        go.GetComponent<Slash>().canHurtE = false;
        go.GetComponent<Slash>().canHurtP = true;
        CoolingTime = coolingTime;
        CanAttack = false;
    }
}