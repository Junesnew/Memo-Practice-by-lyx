using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//仅作参数传递用
public class WeaponPara : MonoBehaviour
{
    public bool isSleep;
    public int price=0;
    public int num;
    void Awake()
    {
        isSleep = true;   
    }
}
