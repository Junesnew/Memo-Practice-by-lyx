using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int num;
    public GameObject obj;
    public float coolingTime = 0.4f;
    public float CoolingTime;
    public bool isSleep;
    public AudioSource gunAudio;
    public int energy=0;
    public int angle;
    public void Start()
    {
        gunAudio = this.GetComponent<AudioSource>();
        obj = GameObject.Find("Player");//这步是寻找子弹池
        CoolingTime = coolingTime;
    }

    // Update is called once per frame
    public void Update()
    {
        isSleep = this.GetComponent<WeaponPara>().isSleep; //这里用weaponpara的参数
        if (!isSleep)
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
                    if(obj.GetComponent<Player>().energy>=energy )
                    Attack();//冷却时间重置
                }
            }
        }
    }
    public virtual void Attack()
    {
        
        gunAudio.Play();
        float mx = Input.mousePosition.x;
        float my = Input.mousePosition.y;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mx, my, 0));//获得鼠标位置
        float x = this.GetComponentInParent<Transform>().position.x;
        float y = this.GetComponentInParent<Transform>().position.y;
        obj.GetComponent<BulletPool>().getBullet(4, new Vector3(mousePos.x - x, mousePos.y - y, 0f), 4, new Vector3(x, y, 0f));
        obj.GetComponent<Player>().energy -= energy;
        CoolingTime = coolingTime;
    }

}
