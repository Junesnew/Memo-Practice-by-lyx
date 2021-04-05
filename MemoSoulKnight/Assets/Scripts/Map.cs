using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //达到的功能：开关门，生成怪物，生成箱子，怪物计数与怪物活性控制，
    struct Room
    {
        int xl, yl, xr, yr;//左下方，右上方的点坐标在
        int EnemyNum;
        GameObject Doors;
        int state;//0:未进入  1：进入   2：清理完毕
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
