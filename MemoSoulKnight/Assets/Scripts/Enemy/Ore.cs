using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    /*
   * 待补充：
   * 精英状态
   * 
   */
    // Start is called before the first frame update
    public bool isDeath = false;
    public int life = 12;//生命值
    public int damage;
    public GameObject player;
    bool isDrop;
    public virtual void Start()
    {
        isDrop = false;

        player = GameObject.Find("Player");

        isDeath = false;
        life = 50;
    }
    // Update is called once per frame
    void Update()
    {

        if (life <= 0)
        {
            isDeath = true;
            this.GetComponent<MoveAnimation>().isDeath = true;
            if (!isDrop)
            {
                for (int i = 0; i < 10; i++)
                {
                    GameObject go;
                    if (this.name=="GoldOre(Clone)")
                        go = (GameObject)Instantiate(Resources.Load("Preset/Back/Coin"));
                    else go = (GameObject)Instantiate(Resources.Load("Preset/Back/EnergyBall"));
                    go.transform.position = this.transform.position;
                }
            }
            isDrop = true;
        }
    
        if (!isDeath)
        {
            damage = this.GetComponent<EnemyPara>().damage;
            if (damage > 0)
            {
                life -= damage;
                this.GetComponent<EnemyPara>().damage = 0;
                damage = 0;
            }
        }
    }
}

   

