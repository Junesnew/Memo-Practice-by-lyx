using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//互动的对象有：宝箱；有价格的武器；雇佣兵；血瓶蓝瓶；
public class Collector : MonoBehaviour
{
    public GameObject weapon;

    // Start is called before the first frame update
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        weapon = null;
        go = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0);//跟随玩家
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (weapon != null)
                go.GetComponent<Player>().pickUp(weapon);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if((collision.tag=="Weapon")&&(collision.GetComponent<Weapon>().isSleep==true))
        {

            //弹出gui
            weapon = collision.gameObject;
           
        }
        //这里缺金币和能量的拾取代码
        //还有与箱子的互动代码；
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject==weapon)
        {
            //关闭gui
            weapon = null;

        }
    }
}
