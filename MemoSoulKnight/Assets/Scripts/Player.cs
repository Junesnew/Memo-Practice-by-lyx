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
 */
public class Player : MonoBehaviour  //最特殊的脚本，需要好多细节的优化
{
    public int life = 6;
    public int shield = 6;
    public int energy = 200;
    public bool death = false;
    enum Weapon { gun,sword,bow,staff,hand};
    Weapon mainWeapon, viceWeapon;

    // Start is called before the first frame update
    void Start()
    {
        life = 6;
        shield = 6;
        energy = 200;
        mainWeapon =Weapon.gun;
    }
    // Update is called once per frame
    void Update()
    {
        if (life <= 0) death = true;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int i;
        GameObject go = collision.gameObject;
        if(go.tag=="EnemyBullet")
        {

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
}
