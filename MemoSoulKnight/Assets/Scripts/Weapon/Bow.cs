using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject obj;
    public float coolingTime = 0.4f;
    public float CoolingTime;
    public bool isSleep;
    public AudioSource gunAudio;
    public int energy = 0;
    public int angle;
    GameObject go;
    float time = 0;
    int array = 0;//是否蓄力中
    Vector3 mousePos;
    float mx, my, x, y;
    bool j;
    public int num;
    public void Start()
    {
        gunAudio = this.GetComponent<AudioSource>();
        obj = GameObject.Find("Player");
        CoolingTime = coolingTime;
    }

    // Update is called once per frame
    public void Update()
    {
        isSleep = this.GetComponent<WeaponPara>().isSleep; //这里用weaponpara的参数
        if (!isSleep)
        {
            if (CoolingTime > 0)
            {
                CoolingTime -= Time.deltaTime;
            }
            else
            {

                if (Input.GetMouseButtonDown(0)) array = 1;
                if (Input.GetMouseButtonUp(0)) array = 3;
                if (array >=1)
                {
                    if (obj.GetComponent<Player>().energy >= energy)

                    {
                        mx = Input.mousePosition.x;
                        my = Input.mousePosition.y;
                         mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mx, my, 0));//获得鼠标位置
                        x = this.GetComponentInParent<Transform>().position.x;
                        y = this.GetComponentInParent<Transform>().position.y;

                        if (array == 1)
                        {
                            go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Array"));
                            go.GetComponent<ArrayMove>().canHurtE = true;
                            go.GetComponent<ArrayMove>().canHurtP = false;
                            go.GetComponent<ArrayMove>().angle = new Vector3(mousePos.x - x, mousePos.y - y, 0f);
                            go.transform.position = new Vector3(x, y, 0f);
                            go.GetComponent<ArrayMove>().speed = 0;
                            array = 2;
                            go.GetComponent<ArrayMove>().isSleep = true;
                            time = 0;
                            j = true;
                        }
                        if (array ==2)
                        {
                            if (time <= 2)
                                time += Time.deltaTime;

                            go.GetComponent<ArrayMove>().angle = new Vector3(mousePos.x - x, mousePos.y - y, 0f);
                            go.GetComponent<Rigidbody2D>().position = this.transform.position;
                        }
                        if (array == 3&&j)
                        {
                            go.GetComponent<ArrayMove>().damage = (int)time * 5+2;
                            go.GetComponent<ArrayMove>().speed = time * 3+2;
                            CoolingTime = coolingTime;
                            obj.GetComponent<Player>().energy -= energy;
                            gunAudio.Play();
                            go.GetComponent<ArrayMove>().isSleep = false;
                            array = 0;
                            time = 0;
                            j = false;
                        }
                    }
                }
               
               
            }

        }
    }
}
