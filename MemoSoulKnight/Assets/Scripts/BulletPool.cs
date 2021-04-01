using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour   //子弹池脚本，该脚本本身问题不大
{
    private List<GameObject> Pool1;
    private List<GameObject> Pool2;
    private List<GameObject> Pool3;
    private List<GameObject> Pool4;
    private List<GameObject> Pool5;
    public int[] num = { 0, -1, -1, -1, -1, -1 };
    GameObject preset1;
    GameObject preset2;
    GameObject preset3;
    GameObject preset4;
    GameObject preset5;
    List<GameObject> pool1 = new List<GameObject>();
    List<GameObject> pool2 = new List<GameObject>();
    List<GameObject> pool3 = new List<GameObject>();
    List<GameObject> pool4 = new List<GameObject>();
    List<GameObject> pool5 = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        preset1 = (GameObject)Resources.Load("Preset/Bullet/Bullet1");
        preset2 = (GameObject)Resources.Load("Preset/Bullet/Bullet2");
        preset3 = (GameObject)Resources.Load("Preset/Bullet/Bullet3");
        preset4 = (GameObject)Resources.Load("Preset/Bullet/Bullet4");
        preset5 = (GameObject)Resources.Load("Preset/Bullet/Bullet5");

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void getBullet(int i, Vector3 angle, float speed, Vector3 position)//i指子弹序号,这个angle是三维向量，但z要为零
    {
        GameObject temp;
        switch (i)
        {
            case 1:
                if (num[i] != -1)
                {
                    pool1[num[i]].SetActive(true);

                    pool1[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool1[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool1[num[i]].GetComponent<BulletMove>().position = position;
                    pool1[num[i]].GetComponent<BulletMove>().reStart();
                    pool1.Remove(pool1[num[i]]);
                    num[i]--;

                }
                else
                {
                    temp = Instantiate(preset1);
                    temp.GetComponent<BulletMove>().angle = angle;
                    temp.GetComponent<BulletMove>().speed = speed;
                    temp.GetComponent<BulletMove>().position = position;
                }
                break;
            case 2:
                if (num[i] != -1)
                {
                    pool2[num[i]].SetActive(true);

                    pool2[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool2[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool2[num[i]].GetComponent<BulletMove>().position = position;
                    pool2[num[i]].GetComponent<BulletMove>().reStart();
                    pool2.Remove(pool2[num[i]]);
                    num[i]--;

                }
                else
                {
                    temp = Instantiate(preset2);
                    temp.GetComponent<BulletMove>().angle = angle;
                    temp.GetComponent<BulletMove>().speed = speed;
                    temp.GetComponent<BulletMove>().position = position;
                }
                break;
            case 3:
                if (num[i] != -1)
                {
                    pool3[num[i]].SetActive(true);

                    pool3[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool3[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool3[num[i]].GetComponent<BulletMove>().position = position;
                    pool3[num[i]].GetComponent<BulletMove>().reStart();
                    pool3.Remove(pool3[num[i]]);
                    num[i]--;

                }
                else
                {

                    temp = Instantiate(preset3);
                    temp.GetComponent<BulletMove>().angle = angle;
                    temp.GetComponent<BulletMove>().speed = speed;
                    temp.GetComponent<BulletMove>().position = position;
                }
                break;
            case 4:
                if (num[i] != -1)
                {
                    pool4[num[i]].SetActive(true);

                    pool4[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool4[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool4[num[i]].GetComponent<BulletMove>().position = position;
                    pool4[num[i]].GetComponent<BulletMove>().reStart();
                    pool4.Remove(pool4[num[i]]);
                    num[i]--;

                }
                else
                {
                    temp = Instantiate(preset4);
                    temp.GetComponent<BulletMove>().angle = angle;
                    temp.GetComponent<BulletMove>().speed = speed;
                    temp.GetComponent<BulletMove>().position = position;
                }
                break;
            case 5:
                if (num[i] != -1)
                {
                    pool5[num[i]].SetActive(true);

                    pool5[num[i]].GetComponent<BulletMove>().angle = angle;
                    pool5[num[i]].GetComponent<BulletMove>().speed = speed;
                    pool5[num[i]].GetComponent<BulletMove>().position = position;
                    pool5[num[i]].GetComponent<BulletMove>().reStart();
                    pool5.Remove(pool5[num[i]]);
                    num[i]--;

                }
                else
                {
                    temp = Instantiate(preset5);
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
        if (go.name == "Bullet1(Clone)") i = 1;
        else if (go.name == "Bullet2(Clone)") i = 2;
        else if (go.name == "Bullet3(Clone)") i = 3;
        else if (go.name == "Bullet4(Clone)") i = 4;
        else i = 5;
        num[i]++;
        switch (i)
        {
            case 1:
                pool1.Add(go);
                break;
            case 2:
                pool2.Add(go);
                break;
            case 3:
                pool3.Add(go);
                break;
            case 4:
                pool4.Add(go);
                break;
            case 5:
                pool5.Add(go);
                break;

        }
    }
}
