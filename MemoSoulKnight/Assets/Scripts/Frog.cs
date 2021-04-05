using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{

    public override void Move()
    {
        speed = 1f;
        GameObject go = GameObject.Find("Player");
        float x = go.transform.position.x;
        float y = go.transform.position.y;
        distance = Mathf.Sqrt((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x) + (player.transform.position.y - this.transform.position.y) * (player.transform.position.y - this.transform.position.y));
        {
            if (moveT > 0)
            {
                moveT -= Time.deltaTime;
                if (distance >= 2.0)
                {
                    rb.velocity = new Vector2(x - this.transform.position.x, y - this.transform.position.y) * speed;
                }
                else if (distance <= 0.5)
                {
                    rb.velocity = new Vector2(x - this.transform.position.x, y - this.transform.position.y) * speed * (-1);
                }
                else
                rb.velocity = (Quaternion.AngleAxis(moveD, new Vector3(0, 0, 1f)) * (new Vector2(1, 0))) * speed; ;
            }
            else
            {
                moveT = 1f;
                moveD = Random.Range(-180, 180);
            }
        }


    }
    public override void Prepare()
    {
        CanAttack = true;
    }
    override public void Attack()
    {


        GameObject go = GameObject.Find("Player");
        float mx = Input.mousePosition.x;
        float my = Input.mousePosition.y;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mx, my, 0));//获得鼠标位置
       float x = mousePos.x;
        float y = mousePos.y;
        for (int i =0; i <10; i++)
        {
            go.GetComponent<BulletPool>().getBullet(4, Quaternion.AngleAxis(Random.Range(-30,30), new Vector3(0, 0, 1f)) * (new Vector3(x - this.transform.position.x, y - this.transform.position.y, 0)), Random.Range(1f,9f), this.transform.position);
        }

        CoolingTime = coolingTime; CanAttack = false;

    }
}
