using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 待补充：
 * player完全调用武器函数来实现攻击，
 * 被子弹一打中，添加中毒效果
 * 技能：重复使用武器；
 * player与陷阱的互动//这个应该是机关主动实现
 * player与机关的互动，包括吸收金币与能量，手刀等，通过碰撞体实现
 * 武器库
 * 地图部分：
 * 随机生成箱子，
 * 小地图与随机地牢：先画好小地图模板，通过tilemap生成大地图；每个房间有各自的属性
 *奖励房间：特殊房间
 *其他：
 *SL大法，想个办法保存数据？ 
 *
 *
 *
 *
 *武器切换：地上与手里；主手解除父子关系，睡眠，地上建立父子关系，激活；播放音效
 *主手与副手；播放音效；主手关闭，副手打开；
 *武器有激活状态与睡眠状态；
 *
 *
 */
public class Player : MonoBehaviour  //最特殊的脚本，需要好多细节的优化
{
    public int life = 6;
    public int shield = 6;
    public int energy = 200;
    public bool death = false;
    public bool isPoisoning = false;
    public float reShieldTime = 4f;
    float ReShieldTime = 0f;//计时器
  //  string[] weaponName = { "Empty","OldGun", "ShotGun", "Hand", "Knife", "Gatling", "Hammer", "Bow", "SniperGun" };
   public GameObject mainWeapon, viceWeapon;
    // Start is called before the first frame update
    void Start()
    {
        life = 6;
        shield = 6;
        energy = 200;
        death = false;
        isPoisoning = false;
        //   mainName = weaponName[1];
        {
            mainWeapon = (GameObject)Instantiate(Resources.Load("Preset/Weapon/OldGun"));
            mainWeapon.transform.parent = this.gameObject.transform;
            mainWeapon.transform.localPosition  = Vector3.zero;
            //mainWeapon.isSleep = false;
            viceWeapon = null;
            //初始化主副武器
        }
       // viceName = weaponName[0];

    }
    // Update is called once per frame
    void Update()
    {
        {//生命与盾检测
            float t = 1f;//计时器
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
        {//交换主副手武器
            GameObject weapon;
            int w =(int) Input.GetAxis("Mouse ScrollWheel");
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int i;
        GameObject go = collision.gameObject;
        if(go.tag=="EnemyBullet")
        {
            ReShieldTime = reShieldTime;
            if (go.name == "Bullet1(Clone)") i = 4;
            else if (go.name == "Bullet2(Clone)") i = 2;
            else if (go.name == "Bullet3(Clone)") i = 5;
            else i = 3;
            if(shield-i>=0)
            {
                shield -= i;
            }
            else
            {
                life -= i - shield;
                shield = 0;
            }
            this.gameObject.GetComponent<BulletPool>().recycleBullet(go);


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
        }
        else
        {
            viceWeapon.SetActive(true);
            this.transform.DetachChildren();
            viceWeapon.transform.parent = this.transform;
            viceWeapon.transform.localPosition = Vector3.zero;
            viceWeapon.SetActive(false);
          //  mainWeapon.isSleep = true;//代码先欠着
            mainWeapon = pick;
            mainWeapon.transform.parent = this.transform;
            mainWeapon.transform.localPosition = Vector3.zero;
         //   mainWeapon.isSleep = false ;

        }
    }
}
