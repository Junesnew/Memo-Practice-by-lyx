using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public bool isPoison;
    public Vector3 angle;  //传入向量
    public Vector3 position;   //发射时的位置
    GameObject obj;
    public Rigidbody2D rb;
    public bool canHurtP, canHurtE;
    public int crit;
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
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
        rb.velocity = new Vector2(angle.x * speed * Time.deltaTime * 100, angle.y * speed * Time.deltaTime * 100);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.tag == "Wall")//撞墙
            {
            go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Explode"));
            go.transform.position = this.transform.position;
            go.GetComponent<Explode>().canHurtE = canHurtE ;
            go.GetComponent<Explode>().canHurtP = canHurtP ;
            Destroy(this.gameObject);
            }
            if (collision.tag == "Player" && canHurtP)
            {
            go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Explode"));
            go.transform.position = this.transform.position;
            go.GetComponent<Explode>().canHurtE = canHurtE;
            go.GetComponent<Explode>().canHurtP = canHurtP;
            Destroy(this.gameObject);
        }
            if (collision.tag == "Enemy" && canHurtE)
            {
            go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Explode"));
            go.transform.position = this.transform.position;
            go.GetComponent<Explode>().canHurtE = canHurtE;
            go.GetComponent<Explode>().canHurtP = canHurtP;
            Destroy(this.gameObject);
        }
            if (collision.tag == "Box")
            {
            go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Explode"));
            go.transform.position = this.transform.position;
            go.GetComponent<Explode>().canHurtE = canHurtE;
            go.GetComponent<Explode>().canHurtP = canHurtP;
            Destroy(this.gameObject);
        }
        
    }
    public void create()
    {
        GameObject go;

        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Bomb"));
        go.GetComponent<Bomb>().canHurtE = true;
        go.GetComponent<Bomb>().canHurtP = false;
        go.GetComponent<Bomb>().angle = angle;
        go.GetComponent<Bomb>().speed = speed;
        go.GetComponent<Bomb>().position = position;
    }
}
