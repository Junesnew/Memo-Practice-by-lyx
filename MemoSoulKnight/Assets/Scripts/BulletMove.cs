using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //子弹通过transform移动，应该改为刚体移动，否则会冲突
    //子弹刚体移动/主动攻击 与现在的被动吸收伤害冲突，不利于代码拓展性
    public float xx, yy;//测试用
    public float speed;
    public Vector3 angle;
    public Vector3 position;
    public float time;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player");
        time = 4.0f;
        this.transform.position = position;
        float a = Mathf.Atan2(angle.y, angle.x);
        this.transform.rotation = Quaternion.Euler(0f, 0f, a*180/Mathf.PI);
       angle = angle / Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y);
    }
    public void reStart()
    {
        obj = GameObject.Find("Player");
        time = 4.0f;
        this.transform.position = position;
        float a = Mathf.Atan2(angle.y, angle.x);
        this.transform.rotation = Quaternion.Euler(0f, 0f, a * 180 / Mathf.PI);
        angle = angle / Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(time>0)
        {
            time -= Time.deltaTime;

        }
        else { obj.GetComponent<BulletPool>().recycleBullet(this.gameObject); }
        xx = Input.mousePosition.x;
        yy = Input.mousePosition.y;
        this.transform.position += angle * speed * Time.deltaTime;
    }
}
