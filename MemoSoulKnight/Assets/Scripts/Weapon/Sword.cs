using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon 
{
    GameObject go;
    override public void Attack()
    {
        //obj.GetComponent<BulletPool>().getBullet(4, Quaternion.AngleAxis((float)Random.Range(-angle, angle), new Vector3(0, 0, 1f)) * (new Vector3(mousePos.x - x, mousePos.y - y, 0f)), 3.0f, new Vector3(x, y, 0f));
        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Knife"));
        go.transform.position = this.transform .position;
        go.transform.localScale = new Vector3(this.transform.parent.transform.localScale.x, 1, 1);
        go.GetComponent<Knife>().canHurtE = true;
        go.GetComponent<Knife>().canHurtP = false;

        obj.GetComponent<Player>().energy -= energy;
        CoolingTime = coolingTime;
    }
}
