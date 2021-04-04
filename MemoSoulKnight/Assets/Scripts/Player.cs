using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 待补充：
 * player与机关的互动，手刀等，通过碰撞体实现
 * 武器库
 * 
 * 
 * 地图部分：
 * 随机生成箱子，
 * 小地图与随机地牢：先画好小地图模板，通过tilemap生成大地图；每个房间有各自的属性
 *奖励房间：特殊房间
 *其他：
 *SL大法，想个办法保存数据？ 
 *
 */
public class Player : MonoBehaviour  //最特殊的脚本，需要好多细节的优化
{
    public int coin=0;
    public int life = 6;
    public int shield = 6;
    public int energy = 200;
    public bool death = false;
    public float PoisonTime;//计时器
    float reShieldTime = 4f;
    public int damage;
    public float ReShieldTime = 0f;//计时器
    public float i, t;//计时器
    float skillTime = 10f;
    public float SkillTime=0f;
    public GameObject skillGun;
    public AudioSource hurtAudio;
   public  GameObject Hand;
    //  string[] weaponName = { "Empty","OldGun", "ShotGun", "Hand", "Knife", "Gatling", "Hammer", "Bow", "SniperGun" };
    public GameObject mainWeapon, viceWeapon;
    // Start is called before the first frame update
    private void Awake()
    {

        Hand = (GameObject)Instantiate(Resources.Load("Preset/Weapon/Hand"));
        Hand.transform.parent = this.gameObject.transform;
        Hand.transform.localPosition = Vector3.zero;
        Hand.GetComponent<WeaponPara>().isSleep = true;
    }
    void Start()
    {
        i = t = 1f;
        life = 6;
        shield = 6;
        energy = 200;
        death = false;
        PoisonTime = 0f;
        //   mainName = weaponName[1];
        {
            mainWeapon = (GameObject)Instantiate(Resources.Load("Preset/Weapon/OldGun"));
            mainWeapon.transform.parent = this.gameObject.transform;
            mainWeapon.transform.localPosition  = Vector3.zero;
            mainWeapon.transform.localScale = Vector3.one;
            mainWeapon.GetComponent<WeaponPara>().isSleep  = false;
         

            viceWeapon = null;
            //初始化主副武器
        }
       // viceName = weaponName[0];

    }
    // Update is called once per frame
    void Update()
    {
        {//技能  已完善
            if (Input.GetMouseButtonDown(1))
            {
                if (SkillTime <= 0)
                {
                    SkillTime = skillTime;
                    skillGun = (GameObject)Instantiate(mainWeapon);
                    skillGun.transform.parent = this.gameObject.transform;
                    skillGun.transform.localPosition = new Vector3(0.1f, -0.05f, 0f);
                    skillGun.transform.localScale = Vector3.one;
                    skillGun.GetComponent<WeaponPara>().isSleep = false;
                }
            }
            if(SkillTime>0)
            {
                SkillTime -= Time.deltaTime;
            }
            else
            {
                GameObject.Destroy(skillGun);
                SkillTime = 0;
            }
        }


        if(life<=0)
        {
            death = true;//结束游戏，缺代码
        }


        {//伤害计算，毒伤计算
            if(PoisonTime>-0.1)
            {
                PoisonTime -= Time.deltaTime;
                i -= Time.deltaTime;
                if(i<=0)
                {
                    i = 1f;
                    damage += 1;
                }
            }

            if(damage>0)
            {
                if (shield - damage  >= 0)
                {
                    shield -= damage ;
                }
                else
                {
                    life -= damage  - shield;
                    shield = 0;
                }
                ReShieldTime = reShieldTime;
                hurtAudio.Play();
                damage = 0;
            }
        }
        {//生命与盾检测
            if (life <= 0) death = true;
            if (ReShieldTime >= 0)
            {
                ReShieldTime -= Time.deltaTime;
            }
            else if (shield < 6)
            {
                if (t <= 0)
                {
                    shield++;
                    t = 1f;
                }
                else t -= Time.deltaTime;
            }
        }


        {//交换主副手武器  已完善
           
            GameObject weapon;
            float w = Input.GetAxis("Mouse ScrollWheel");
            if(w!=0)
            {
              //播放音效
                if(viceWeapon!=null)
                {
                    weapon = mainWeapon;
                    mainWeapon = viceWeapon;
                    viceWeapon = weapon;
                    mainWeapon.SetActive(true);
             
                    viceWeapon.SetActive(false);//待测试，不知道行不行
                }

            }
        }
    }

   public void pickUp(GameObject pick)
    {
   if(viceWeapon==null)
        {
            viceWeapon = mainWeapon;
            viceWeapon.SetActive(false);
            mainWeapon = pick;
            mainWeapon.transform.parent = this.transform;
            mainWeapon.transform.localPosition = Vector3.zero;
            mainWeapon.transform.localScale = Vector3.one;
            mainWeapon.GetComponent<WeaponPara>().isSleep = false;
        }
        else
        {
            viceWeapon.SetActive(true);
            this.transform.DetachChildren();
            viceWeapon.transform.parent = this.transform;
            viceWeapon.transform.localPosition = Vector3.zero;
            viceWeapon.SetActive(false);
            mainWeapon.GetComponent <WeaponPara>().isSleep = true;//代码先欠着
            mainWeapon = pick;
            mainWeapon.transform.parent = this.transform;
            mainWeapon.transform.localPosition = Vector3.zero;
            mainWeapon.transform.localScale = Vector3.one;
            mainWeapon.GetComponent<WeaponPara>().isSleep = false ;

        }
    }
}
