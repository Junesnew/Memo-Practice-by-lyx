using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.GetComponent<Player>().coin += 5;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Collector")
        {
            go = GameObject.Find("Player");
            this.transform.position += new Vector3(go.transform.position.x - this.transform.position.x, go.transform.position.y - this.transform.position.y) * Time.deltaTime * 10;
        }
    }
}
