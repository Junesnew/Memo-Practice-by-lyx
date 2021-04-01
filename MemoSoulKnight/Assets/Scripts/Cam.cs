using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour//这是控制镜头的脚本，别改
{
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, -1);
    }
}
