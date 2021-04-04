using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMachineGun : Weapon 
{
    public int i;
    override public void Attack()
    {
        gunAudio.Play();
        float mx = Input.mousePosition.x;
        float my = Input.mousePosition.y;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mx, my, 0));//获得鼠标位置
        float x = this.GetComponentInParent<Transform>().position.x;
        float y = this.GetComponentInParent<Transform>().position.y;
        Vector3 vec = new Vector3(mousePos.x - x, mousePos.y - y, 0f);
        vec = vec / Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y);
        for (i = -1; i < 2; i+=2)
        {
            obj.GetComponent<BulletPool>().getBullet(4,(new Vector3(mousePos.x - x, mousePos.y - y, 0f)), 3.0f, (new Vector3(x, y, 0f))+ (Quaternion.AngleAxis((float)i*90 , new Vector3(0, 0, 1f))*vec)*0.1f);
        }
        obj.GetComponent<Player>().energy -= energy;
        CoolingTime = coolingTime;
    }
}
