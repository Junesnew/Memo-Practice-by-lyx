using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//仅作参数传递用
public class EnemyPara : MonoBehaviour
{
    public int damage=0;
    public bool isElite;
    public bool isDeath;
    bool set;
    public GameObject Room=null;
    private void Awake()
    {
        isDeath = false;
        damage = 0;
        set = false;
    }
    public void Update()
    {
        if(isDeath)
        {
            if ((!set)&&(Room!=null))
            { Room.GetComponent<Room>().num -= 1; set = true; }
        }

    }
}
