using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabSword : Weapon 
{
    GameObject go;
    override public void Attack()
    {
        //obj.GetComponent<BulletPool>().getBullet(4, Quaternion.AngleAxis((float)Random.Range(-angle, angle), new Vector3(0, 0, 1f)) * (new Vector3(mousePos.x - x, mousePos.y - y, 0f)), 3.0f, new Vector3(x, y, 0f));
        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Punch"));
        go.transform.position = this.transform .position+( new Vector3(this.transform.parent.transform.localScale.x*0.25f, 0, 0));
        go.transform.localScale = new Vector3(this.transform.parent.transform.localScale.x, 1, 1);
        go.GetComponent<Punch>().canHurtE = true;
        go.GetComponent<Punch>().canHurtP = false;

        obj.GetComponent<Player>().energy -= energy;
        CoolingTime = coolingTime;
    }
}
