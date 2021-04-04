using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin2 :Enemy
{
    public override void Prepare()
    {
        CanAttack = true;
    }
    override public void Attack()
    {

        GameObject obj = GameObject.Find("Player");
        float x = obj.transform.position.x;
        float y = obj.transform.position.y;

        GameObject go;
        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Array"));
        go.GetComponent<ArrayMove>().canHurtE = false;
        go.GetComponent<ArrayMove>().canHurtP = true;
        go.GetComponent<ArrayMove>().damage = AttackPower;
        go.GetComponent<ArrayMove>().angle = new Vector3(x - this.transform.position.x, y - this.transform.position.y, 0);
        go.GetComponent<ArrayMove>().speed = 2f;
        go.GetComponent<ArrayMove>().position = this.transform.position;

        CoolingTime = coolingTime; CanAttack = false;
    }
}

