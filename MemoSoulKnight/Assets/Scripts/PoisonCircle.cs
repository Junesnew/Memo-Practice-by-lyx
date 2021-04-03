using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCircle : MonoBehaviour
{
    public float hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().PoisonTime = 4f;
        }
        if (hit <= 0)
        {
            if (collision.tag == "Enemy")
                collision.GetComponent<EnemyPara>().damage = 1;
            hit = 1;
        }
        else
        {
            hit -= Time.deltaTime;
        }
    }
    public void Create(Vector3 position)
    {
        GameObject go;
        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/PoisonCircle"));
        go.transform.position = position;
    }
}
