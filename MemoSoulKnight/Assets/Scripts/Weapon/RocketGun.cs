using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGun : Weapon
{
    GameObject go;
    public int i;
    override public void Attack()
    {
        gunAudio.Play();
        float mx = Input.mousePosition.x;
        float my = Input.mousePosition.y;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mx, my, 0));//获得鼠标位置
        float x = this.GetComponentInParent<Transform>().position.x;
        float y = this.GetComponentInParent<Transform>().position.y;

        

        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Bomb"));
        go.GetComponent<Bomb>().canHurtE = true;
        go.GetComponent<Bomb>().canHurtP = false;
        go.GetComponent<Bomb>().angle = (new Vector3(mousePos.x - x, mousePos.y - y, 0f));
        go.GetComponent<Bomb>().speed = 1;
        go.GetComponent<Bomb>().position = this.transform.position;

        obj.GetComponent<Player>().energy -= energy;
        CoolingTime = coolingTime;
    }
}
