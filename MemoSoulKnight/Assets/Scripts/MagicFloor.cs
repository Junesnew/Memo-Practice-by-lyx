using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicFloor : MonoBehaviour
{
    public float i;
    // Start is called before the first frame update
    void Start()
    {
        i = (this.gameObject.name == "Up") ? 2f : -1.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            collision.GetComponent<PlayerMove>().speederTime = 4f;
            collision.GetComponent<PlayerMove>().deltaSpeed  = i;
        }
    }

}
