using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGun : MonoBehaviour  //武器原型
{
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {

        obj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        
        bool i = Input.GetMouseButtonDown(0);
        if(i)
        {
            float mx = Input.mousePosition.x;
            float my = Input.mousePosition.y;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mx, my, 0));//获得鼠标位置
            float x = this.GetComponentInParent<Transform>().position.x;
            float y = this.GetComponentInParent<Transform>().position.y;
            obj.GetComponent<BulletPool>().getBullet(4, new Vector3(mousePos.x  - x,mousePos.y- y, 0f ), 3.0f, new Vector3(x,y,0f));
        }
    }
}
