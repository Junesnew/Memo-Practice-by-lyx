using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        bool i = Input.GetMouseButtonDown(0);
        if(i)
        {
            GetComponent<BulletPool>().Link =(1, new Vector3(Input.mousePosition.x - x, Input.mousePosition.y - y, 0f ), 0.8f, this.transform.position);
            GetComponent<BulletPool>().link = true ;
        }
    }
}
