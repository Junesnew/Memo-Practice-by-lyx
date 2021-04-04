using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayMove : MonoBehaviour
{
    public float speed=10;
    public int damage;
    public bool isPoison;
    public Vector3 angle;  //传入向量
    public Vector3 position;   //发射时的位置
    GameObject obj;
    public Rigidbody2D rb;
    public bool isSleep;
    public bool canHurtP, canHurtE;
    public int crit;
    // Start is called before the first frame update
    void Start()                             
    {
        isSleep = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();  //寻找刚体
        rb.position = position;
        float a = Mathf.Atan2(angle.y, angle.x);           //子弹旋转角
        rb.rotation = a * 180 / Mathf.PI;
        angle = angle / Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y);   //单位向量

    }
    void FixedUpdate()
    {
        float a = Mathf.Atan2(angle.y, angle.x);           //子弹旋转角
        rb.rotation = a * 180 / Mathf.PI;
        if (!isSleep)
        {
            rb.velocity = new Vector2(angle.x * speed * Time.deltaTime * 100, angle.y * speed * Time.deltaTime * 100);
        }
        else {rb.velocity = Vector2.zero; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSleep)
        {
            if (collision.tag == "Wall")//撞墙
            {
                isSleep = true;
            }
            if (collision.tag == "Player" && canHurtP)
            {

                collision .GetComponent<Player>().damage = damage ;
                Destroy(this.gameObject);
                this.transform.parent = collision.transform;
            }
            if (collision.tag == "Enemy" && canHurtE)
            {
                if (collision.GetComponent<MoveAnimation>().isDeath == false)
                {
                    collision.gameObject.GetComponent<EnemyPara>().damage = damage * Random.Range(1, 2);
                    Destroy(this.gameObject);
                    this.transform.parent = collision.transform;
                }
            }
            if (collision.tag == "Box")
            {
                collision.GetComponent<Box>().Clear();
                Destroy(this.gameObject);
            }
        }
    }
    public void create()
    {
        GameObject go;

        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Array"));
        go.GetComponent<ArrayMove>().canHurtE = true;
        go.GetComponent<ArrayMove>().canHurtP = false;
        go.GetComponent<ArrayMove>().damage = damage;
        go.GetComponent<ArrayMove>().angle = angle;
        go.GetComponent<ArrayMove>().speed = speed;
        go.GetComponent<ArrayMove>().position = position;
    }
}
