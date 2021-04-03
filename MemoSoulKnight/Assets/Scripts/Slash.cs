using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public bool canHurtP, canHurtE;//能否伤害玩家或敌人
    public float time;
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canHurtP)
        {
            if (collision.tag == "Player")
            { collision.GetComponent<Player>().damage = 4; }
        }
        if (canHurtE)
        {
            if (collision.tag == "Enemy")
                collision.GetComponent<EnemyPara>().damage = 6;
        }
        if (collision.tag == "Box") collision.GetComponent<Box>().Clear();

    }
    public void Create(Vector3 position)
    {
        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Slash"));
        go.transform.position = position;
        go.GetComponent<ShockWave>().canHurtE = true;
        go.GetComponent<ShockWave>().canHurtP = false;
    }
}
