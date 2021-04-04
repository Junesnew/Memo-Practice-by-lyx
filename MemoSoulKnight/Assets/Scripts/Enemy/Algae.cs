using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algae : Enemy 
{
    public override void Move()
    {
        rb.velocity = Vector2.zero;
    }
    public override void Prepare()
    {
        CanAttack = true;
    }
    override public void Attack()
    {


        GameObject go = GameObject.Find("Player");
        float x = go.transform.position.x;
        float y = go.transform.position.y;

        for (int i = -9; i < 9; i++)
        {
            go.GetComponent<BulletPool>().getBullet(2, Quaternion.AngleAxis(20 * i, new Vector3(0, 0, 1f)) * (new Vector3(x - this.transform.position.x, y - this.transform.position.y, 0)), 0.1f, this.transform.position+ Quaternion.AngleAxis(20 * i, new Vector3(0, 0, 1f)) * (new Vector3(x - this.transform.position.x, y - this.transform.position.y, 0))*0.1f);
        }

        CoolingTime = coolingTime;
        CanAttack = false;
    }
}
