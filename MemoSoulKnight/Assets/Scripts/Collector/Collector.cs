using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//互动的对象有：宝箱；有价格的武器；雇佣兵；
public class Collector : MonoBehaviour
{
    public GameObject weapon;
    GameObject mainWeapon;
    // Start is called before the first frame update
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        weapon = null;
        go = GameObject.Find("Player");

        mainWeapon = GameObject.Find("Player").GetComponent<Player>().Hand;
          
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0);//跟随玩家
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (weapon != null)
                go.GetComponent<Player>().pickUp(weapon);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.tag == "Weapon") && (collision.GetComponent<WeaponPara>().isSleep == true))
        {

            //弹出gui
            weapon = collision.gameObject;

        }
     
        //还有与箱子的互动代码；
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            mainWeapon.GetComponent<WeaponPara>().isSleep = true;
            GameObject.Find("Player").GetComponent<Player>().mainWeapon.GetComponent<WeaponPara>().isSleep = false;
        }
        if (collision.gameObject == weapon)
        {
            //关闭gui
            weapon = null;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag =="Enemy"&&collision.GetComponent<MoveAnimation>().isDeath==false)
        {
            mainWeapon.GetComponent<WeaponPara>().isSleep = false;
            GameObject.Find("Player").GetComponent<Player>().mainWeapon.GetComponent<WeaponPara>().isSleep = true;

        }
        if (collision.tag == "Bottle")//蓝瓶血瓶判定
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (collision.name == "HPsmall")
                {
                    if (go.GetComponent<Player>().life <= 4) { go.GetComponent<Player>().life += 2; } else { go.GetComponent<Player>().life = 6; }
                }
                else if (collision.name == "HPbig")
                {
                    if (go.GetComponent<Player>().life <= 2) { go.GetComponent<Player>().life += 4; } else { go.GetComponent<Player>().life = 6; }
                }
                else if (collision.name == "MPsmall")
                {
                    if (go.GetComponent<Player>().energy <= 160) { go.GetComponent<Player>().energy += 40; } else { go.GetComponent<Player>().energy = 200; }
                }
                else if (collision.name == "MPbig")
                {
                    if (go.GetComponent<Player>().energy <= 100) { go.GetComponent<Player>().energy += 100; } else { go.GetComponent<Player>().energy = 200; }
                }
                else if (collision.name == "HMsmall")
                {
                    if (go.GetComponent<Player>().life <= 4) { go.GetComponent<Player>().life += 1; } else { go.GetComponent<Player>().life = 6; }
                    if (go.GetComponent<Player>().energy <= 180) { go.GetComponent<Player>().energy += 20; } else { go.GetComponent<Player>().energy = 200; }
                }
                else if (collision.name == "HMbig")
                {
                    if (go.GetComponent<Player>().life <= 4) { go.GetComponent<Player>().life += 2; } else { go.GetComponent<Player>().life = 6; }
                    if (go.GetComponent<Player>().energy <= 150) { go.GetComponent<Player>().energy += 50; } else { go.GetComponent<Player>().energy = 200; }
                }
                Destroy(collision.gameObject);//清除瓶子
            }
        }

        if (collision.tag == "Chest" && collision.name == "EnergyChest(Clone)")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                for (int i = 0; i < 4; i++)
                {
                    GameObject go;
                    go = (GameObject)Instantiate(Resources.Load("Preset/Back/EnergyBall"));
                    go.transform.position = collision .transform.position;
                    Destroy(collision.gameObject);
                }

            }
        }
        if (collision.tag == "Chest" && collision.name == "WeaponChest(Clone)")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                int i=Random.Range(0, 11);
                string[] str = {"Bow", "Gatling", "MachineGun", "OldGun", "RedShotGun", "RocketGun", "SniperGun", "SniperGun", "Staff", "SubMachineGun", "Sword" };

                GameObject go;
                go = (GameObject)Instantiate(Resources.Load("Preset/Weapon/"+str[i]));
                go.transform.position = collision .transform.position;
                Destroy(collision.gameObject);
            }
        }
        
    }
}
