using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public string name;
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        name = this.gameObject.name;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Clear()
    {
        if(name=="Box")
        Destroy(this.gameObject);
        else if(name=="ExplodeBox")
        {
            go=(GameObject)Instantiate(Resources.Load("Preset/Bullet/Explode"));
            go.GetComponent<Explode>().canHurtE = true;
            go.GetComponent<Explode>().canHurtP = true;
            go.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        else if (name=="NailBox")
        {//钉子盒，生成四个方向的子弹；

            GameObject.Find("Player").GetComponent<BulletPool>().getBullet(5, new Vector3(1, 0, 0), 3.0f, this.transform.position);
            GameObject.Find("Player").GetComponent<BulletPool>().getBullet(5, new Vector3(-1, 0, 0), 3.0f, this.transform.position);
            GameObject.Find("Player").GetComponent<BulletPool>().getBullet(5, new Vector3(0, 1, 0), 3.0f, this.transform.position);
            GameObject.Find("Player").GetComponent<BulletPool>().getBullet(5, new Vector3(0, -1, 0), 3.0f, this.transform.position);
            Destroy(this.gameObject);
        }
        else if(name=="PoisonBox")
        {
          
            go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/PoisonCircle"));
            go.transform.position = this.transform.position;
            Destroy(this.gameObject);

        }
    }
}
