using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    GameObject obj;
    public float coolingTime = 0.4f;
    public float CoolingTime;
    public bool isSleep = true;
    //缺一个被检判定
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player");//这步是寻找子弹池
        CoolingTime = coolingTime;
        isSleep = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CoolingTime > 0)
        {
            CoolingTime -= Time.deltaTime;
        }
        else
        {
            bool i = Input.GetMouseButton(0);
            if (i)
            {
                Attack();//冷却时间重置

                //float mx = Input.mousePosition.x;
                //float my = Input.mousePosition.y;
                //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mx, my, 0));//获得鼠标位置
                //float x = this.GetComponentInParent<Transform>().position.x;
                //float y = this.GetComponentInParent<Transform>().position.y;
                //obj.GetComponent<BulletPool>().getBullet(4, new Vector3(mousePos.x  - x,mousePos.y- y, 0f ), 3.0f, new Vector3(x,y,0f));
            }
        }
    }
    public virtual void Attack()
    {
        float mx = Input.mousePosition.x;
        float my = Input.mousePosition.y;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mx, my, 0));//获得鼠标位置
        float x = this.GetComponentInParent<Transform>().position.x;
        float y = this.GetComponentInParent<Transform>().position.y;
        obj.GetComponent<BulletPool>().getBullet(4, new Vector3(mousePos.x - x, mousePos.y - y, 0f), 3.0f, new Vector3(x, y, 0f));
        CoolingTime = coolingTime;
    }

}
