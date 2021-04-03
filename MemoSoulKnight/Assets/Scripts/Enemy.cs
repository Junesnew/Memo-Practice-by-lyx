using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
   * 待补充：
   * 精英状态
   * 掉落物，添加在死亡效果
   */
    // Start is called before the first frame update
    public bool isElite = false;
    public bool isDeath = false;
    public bool isShooter = true;                
    public static float coolingTime = 3.0f;      //攻击最短冷却时间
    public float CoolingTime;//计时器
    public int life = 8;//生命值
    public int damage;
    public int AttackPower = 4;
    public bool CanAttack = false;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
        if(life<=0)
        {
            isDeath = true;
        }
        if (!isDeath)
        {
            damage = this.GetComponent<EnemyPara>().damage;
            if (damage >0)
            {
                life -= damage;
                this.GetComponent<EnemyPara>().damage = 0;
                damage = 0;
            }
            if (CoolingTime > 0)
            {
                CoolingTime -= Time.deltaTime;
            }
            else
            {
                    if (CanAttack)
                        Attack();
                    else Prepare();
            }
        }

    }
    public virtual void Attack()
    {
        //不同怪物攻击方式
        GameObject go = GameObject.Find("Player");
        float x = go.transform.position.x;
        float y = go.transform.position.y;
       // GameObject.Find("Player").GetComponent<BulletPool>().getBullet(5, new Vector3(x - this.transform.position.x, y - this.transform.position.y, 0), 1.6f, this.transform.position);
    }//这里要设置好冷却时间
    public virtual void Prepare()
    {

        //这里要给出CanAttack的条件
    }
}
