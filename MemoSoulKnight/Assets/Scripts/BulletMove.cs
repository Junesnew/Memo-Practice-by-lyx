using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //子弹通过transform移动，应该改为刚体移动，否则会冲突
    //子弹刚体移动/主动攻击 与现在的被动吸收伤害冲突，不利于代码拓展性
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
    public void reStart()               //跟上面完全一样
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
        // this.transform.position += angle * speed * Time.deltaTime;
    }
}
