using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private List<GameObject> Pool1;
    private List<GameObject> Pool2;
    private List<GameObject> Pool3;
    private List<GameObject> Pool4;
    private List<GameObject> Pool5;
    private int[] num= { 0 ,0,0,0,0,};
    GameObject preset1 = (GameObject)Resources.Load("Preset/Bullet/Bullet1");
    GameObject preset2 = (GameObject)Resources.Load("Preset/Bullet/Bullet2");
    GameObject preset3 = (GameObject)Resources.Load("Preset/Bullet/Bullet3");
    GameObject preset4 = (GameObject)Resources.Load("Preset/Bullet/Bullet4");
    GameObject preset5 = (GameObject)Resources.Load("Preset/Bullet/Bullet5");
    List<GameObject> pool1 = new List<GameObject>();
    List<GameObject> pool2 = new List<GameObject>();
    List<GameObject> pool3 = new List<GameObject>();
    List<GameObject> pool4 = new List<GameObject>();
    List<GameObject> pool5 = new List<GameObject>();
    public (int i, Vector3 angle, float speed, Vector3 position) Link;
    public bool link,obj;
    GameObject Obj;
    // Start is called before the first frame update
    void Start()
    {
        link = false;


    }

    // Update is called once per frame
    void Update()
    {
     
        if(link)
        {
            getBullet(Link.i,Link.angle,Link.speed,Link.position);
            link = false;

        }
        if(obj)
        {
            recycleBullet(Obj);
            obj = false;
        }
    }
    public void getBullet(int i, Vector3 angle, float speed,Vector3 position)//i指子弹序号,这个angle是三维向量，但z要为零
    {
        GameObject temp;
        switch(i)
        {
            case 1: 
                if (num[i] != 0)
                {
                    pool1[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool1[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool1[num[i]].GetComponent<BulletMove>().position  = position;
                    num[i]--;

                }
                else
                {
                    temp =Instantiate(preset1, transform);
                    temp.GetComponent<BulletMove>().angle = angle;
                    temp.GetComponent<BulletMove>().speed = speed;
                    temp.GetComponent<BulletMove>().position = position;
                }
                break;
            case 2:
                if (num[i] != 0)
                {
                    pool2[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool2[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool1[num[i]].GetComponent<BulletMove>().position = position;
                    num[i]--;

                }
                else
                {
                    temp = Instantiate(preset1, transform);
                    temp.GetComponent<BulletMove>().angle = angle;
                    temp.GetComponent<BulletMove>().speed = speed;
                    temp.GetComponent<BulletMove>().position = position;
                }
                break;
            case 3:
                if (num[i] != 0)
                {
                    pool3[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool3[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool1[num[i]].GetComponent<BulletMove>().position = position;
                    num[i]--;

                }
                else
                {
                    temp = Instantiate(preset1, transform);
                    temp.GetComponent<BulletMove>().angle = angle;
                    temp.GetComponent<BulletMove>().speed = speed;
                    temp.GetComponent<BulletMove>().position = position;
                }
                break;
            case 4:
                if (num[i] != 0)
                {
                    pool4[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool4[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool1[num[i]].GetComponent<BulletMove>().position = position;
                    num[i]--;

                }
                else
                {
                    temp = Instantiate(preset1, transform);
                    temp.GetComponent<BulletMove>().angle = angle;
                    temp.GetComponent<BulletMove>().speed = speed;
                    temp.GetComponent<BulletMove>().position = position;
                }
                break;
            case 5:
                if (num[i] != 0)
                {
                    pool5[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool5[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool1[num[i]].GetComponent<BulletMove>().position = position;
                    num[i]--;

                }
                else
                {
                    temp = Instantiate(preset1, transform);
                    temp.GetComponent<BulletMove>().angle = angle;
                    temp.GetComponent<BulletMove>().speed = speed;
                    temp.GetComponent<BulletMove>().position = position;
                }
                break;
            default:
                break;
        }
    }
    public void recycleBullet(GameObject go)
    {
        go.SetActive(false);
        int i;
        if (go.name == "Bullet1") i = 1;
        else if (go.name == "Bullet2") i = 2;
        else if (go.name == "Bullet3") i = 3;
        else if (go.name == "Bullet4") i = 4;
        else i = 5;
        switch(i)
        {
            case 1:
                pool1[++num[i]] = go;
                break;
            case 2:
                pool2[++num[i]] = go;
                break;
            case 3:
                pool3[++num[i]] = go;
                break;
            case 4:
                pool4[++num[i]] = go;
                break;
            case 5:
                pool5[++num[i]] = go;
                break;

        }
    }
}
