using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin3 : Enemy 
{
    public override void Prepare()
    {
        CanAttack = true;
    }
    override public void Attack()
    {

    
        GameObject go = GameObject.Find("Player");
        float x = go.transform.position.x;
        float y = go.transform.position.y;

        for (int i = 0; i < 5; i++)
        {
            go.GetComponent<BulletPool>().getBullet(5, Quaternion.AngleAxis((float)Random.Range(-30, 30), new Vector3(0, 0, 1f)) * (new Vector3(x - this.transform.position.x, y - this.transform.position.y, 0)), 1.2f, this.transform.position );
        }

        CoolingTime = coolingTime; CanAttack = false;

    }
}
