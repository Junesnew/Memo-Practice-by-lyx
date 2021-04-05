using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//互动的对象有：宝箱；有价格的武器；雇佣兵；
public class Collector : MonoBehaviour
{
    public GameObject weapon;
    GameObject mainWeapon;
    // Start is called before the first frame update
    GameObject go;
    GameObject Prices;
    // Start is called before the first frame update
    void Start()
    {
        Prices = GameObject.Find("Price");
        Prices.SetActive(false);
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
            {
                if (go.GetComponent<Player>().coin >= weapon.GetComponent<WeaponPara>().price)
                {
                    if (weapon != null)
                        go.GetComponent<Player>().pickUp(weapon);

                    go.GetComponent<Player>().coin -= weapon.GetComponent<WeaponPara>().price;


                }
                else { }
            } //金币不足
            Prices.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.tag == "Weapon") && (collision.GetComponent<WeaponPara>().isSleep == true))
        {
            
            //弹出gui
            weapon = collision.gameObject;
            Prices.SetActive(true);
            Prices.GetComponent<Text>().text = "Price:" + weapon.GetComponent<WeaponPara>().price;
        }
     
        //还有与箱子的互动代码；
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            mainWeapon.GetComponent<WeaponPara>().isSleep = true;//这里的mainweapon是手刀
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
        if(collision.tag =="Enemy"&&collision.GetComponent<MoveAnimation>().isDeath==false) //手刀
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
        if (collision.tag == "PlayerPet" )//雇佣兵
        {

            //显示UI
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (GameObject.Find("Player").GetComponent<Player>().coin >= 30)
                {
                    GameObject.Find("Player").GetComponent<Player>().coin -= 30;
                    collision.GetComponent<Frog>().isSleep = false;
                }
                else { }//金币不足

            }
        }
        if (collision.tag == "Portal")
        {

            //显示UI
            if (Input.GetKeyDown(KeyCode.F))
            {

                SceneManager.LoadScene(GameObject.Find("SaveLoad").GetComponent<SaveLoad>().level++);//这里的level是从1开始的
            }
        }
    }
}
