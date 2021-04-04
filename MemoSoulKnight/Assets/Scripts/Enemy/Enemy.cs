using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
   * 待补充：
   * 精英状态
   * 
   */
    // Start is called before the first frame update
    public bool isElite = false;
    public bool isDeath = false;
    public bool isShooter = true;                
    public static float coolingTime = 5.0f;      //攻击最短冷却时间
    public float CoolingTime;//计时器
    public int life = 12;//生命值
    public int damage;
    public int AttackPower = 4;
    public bool CanAttack = false;
    public int drop = 2;//掉落概率 1/drop；
    public float attackTime;
    public float distance;
    public Rigidbody2D rb;
    public float speed;
    public GameObject player;
    public float moveT=0;
    public int moveD=0;
    bool isDrop;
    public virtual void Start()
    {
        isDrop = false;
        speed = 0.3f;
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        distance = Mathf.Sqrt((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x)+(player.transform.position.y - this.transform.position.y) * (player.transform.position.y - this.transform.position.y));
        if (isElite)
        {
           
            isDeath = false;
            life =(int)1.5*life;
            coolingTime = 0.75f * coolingTime;
            AttackPower = (int)1.5f*AttackPower ;
            drop = 1;
            this.transform.localScale = new Vector3(2, 2, 1);
            attackTime = 4f;
        }
        else
        {
            isDeath = false;
            life = 12;
            coolingTime = 4f;
            AttackPower = 4;
            drop = 3;
            attackTime = 3f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if(life<=0)
        {
            isDeath = true;
            rb.velocity = Vector2.zero;
            this.GetComponent<MoveAnimation>().isDeath = true;
            if (!isDrop)
            {
                if (Random.Range(0, drop) == 0)
                {
                    GameObject go;
                    if (Random.Range(0, 2) == 0)
                        go = (GameObject)Instantiate(Resources.Load("Preset/Back/Coin"));
                    else go = (GameObject)Instantiate(Resources.Load("Preset/Back/EnergyBall"));
                    go.transform.position = this.transform.position;

                }
                isDrop = true;
            }
        }
        if (!isDeath)
        {
            Move();
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
       GameObject.Find("Player").GetComponent<BulletPool>().getBullet(5, new Vector3(x - this.transform.position.x, y - this.transform.position.y, 0), 1.6f, this.transform.position);
        CoolingTime = coolingTime;
        CanAttack = false;
    }//这里要设置好冷却时间


    public virtual void Move()
    {
        GameObject go = GameObject.Find("Player");
        float x = go.transform.position.x;
        float y = go.transform.position.y;
        distance = Mathf.Sqrt((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x) + (player.transform.position.y - this.transform.position.y) * (player.transform.position.y - this.transform.position.y));
        if (distance <= 1)
        {
            rb.velocity = new Vector2(x - this.transform.position.x, y - this.transform.position.y) * speed * (-1);
        }
        else
        {
            if (moveT > 0)
            {
                moveT -= Time.deltaTime;
                rb.velocity = (Quaternion.AngleAxis(moveD, new Vector3(0, 0, 1f)) * (new Vector2(1, 0))) * speed; ;
            }
            else
            {
                moveT = 1f;
                moveD = Random.Range(-180, 180);
            }
        }

    
    }
    public virtual void Prepare()
    {

        distance = Mathf.Sqrt((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x) + (player.transform.position.y - this.transform.position.y) * (player.transform.position.y - this.transform.position.y));
       
        
        //这里要给出CanAttack的条件
    }
}
