using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public int damage;
    public bool isPoison;
    public Vector3 angle;  //传入向量
    public Vector3 position;   //发射时的位置
    public float time;     //子弹留存的时间
    GameObject obj;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()                             //这个函数跟下面那个一模一样，要改都改
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();  //寻找刚体
        obj = GameObject.Find("Player");                   //寻找玩家，子弹池挂在玩家身上
        time = 4.0f;                                       //子弹持续时间
        rb.position =position;
      //  this.transform.position = position;                //子弹初始位置
        float a = Mathf.Atan2(angle.y, angle.x);           //子弹旋转角
        rb.rotation = a * 180 / Mathf.PI;
      //  this.transform.rotation = Quaternion.Euler(0f, 0f, a*180/Mathf.PI);   
       angle = angle / Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y);   //单位向量
   
    }
    public void reStart()              //跟上面完全一样
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>(); 
        obj = GameObject.Find("Player");                  
        time = 4.0f;                                      
        rb.position = position;
        float a = Mathf.Atan2(angle.y, angle.x);           
        rb.rotation = a * 180 / Mathf.PI;
        angle = angle / Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(time>0)
        {
            time -= Time.deltaTime;

        }
        else{ obj.GetComponent<BulletPool>().recycleBullet(this.gameObject); }

        rb.velocity = new Vector2(angle.x * speed*Time .deltaTime*100 , angle.y * speed*Time .deltaTime*100 );
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int i;
        if (collision.tag=="Wall")//撞墙直接消失
        {
            obj.GetComponent<BulletPool>().recycleBullet(this.gameObject);
        }
        if(collision.tag=="Player"&&(this.tag=="EnemyBullet"))
        {
            if (this.name == "Bullet1(Clone)") i = 4;
            else if (this.name == "Bullet2(Clone)") i = 2;
            else if (this.name == "Bullet3(Clone)") i = 5;
            else i = 3;
            obj.GetComponent<Player>().damage = i;
            if (i == 4) obj.GetComponent<Player>().PoisonTime = 4f;
            obj.GetComponent<BulletPool>().recycleBullet(this.gameObject);
        }
        if(collision.tag=="Enemy"&&this.tag=="PlayerBullet")
        {
            collision.gameObject.GetComponent<EnemyPara>().damage = 4;
            obj.GetComponent<BulletPool>().recycleBullet(this.gameObject);
        }
        if(collision.tag=="Box")
        {
            collision.GetComponent<Box>().Clear();
            obj.GetComponent<BulletPool>().recycleBullet(this.gameObject);
        }
    }
}
