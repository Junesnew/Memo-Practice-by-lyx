using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGun : Weapon 
{
    override public void Attack()
    {
        int i;
        gunAudio.Play();
        float mx = Input.mousePosition.x;
        float my = Input.mousePosition.y;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mx, my, 0));//获得鼠标位置
        float x = this.GetComponentInParent<Transform>().position.x;
        float y = this.GetComponentInParent<Transform>().position.y;
            obj.GetComponent<BulletPool>().getBullet(4, Quaternion.AngleAxis((float)Random.Range(-angle, angle), new Vector3(0, 0, 1f)) * (new Vector3(mousePos.x - x, mousePos.y - y, 0f)), 10f, new Vector3(x, y, 0f));
        obj.GetComponent<Player>().energy -= energy;
        CoolingTime = coolingTime;
    }
}
