using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public bool canHurtP, canHurtE;//能否伤害玩家或敌人
    public float time;
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.2f;
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
            { collision.GetComponent<Player>().damage = 3; }
        }
        if (canHurtE)
        {
            if (collision.tag == "Enemy")
                collision.GetComponent<EnemyPara>().damage = 8;
        }
        if (collision.tag == "Box") collision.GetComponent<Box>().Clear();

    }
    public void Create(Vector3 position)
    {
        go = (GameObject)Instantiate(Resources.Load("Preset/Bullet/Punch"));
        go.transform.position = position;
        go.transform.localScale = new Vector3(this.transform.localScale.x, 1, 1);
        go.GetComponent<Punch>().canHurtE = true;
        go.GetComponent<Punch>().canHurtP = false;
    }
}
