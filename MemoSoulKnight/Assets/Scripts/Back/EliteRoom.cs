using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteRoom : MonoBehaviour
{
    public int state;
    public GameObject door;
    public AudioSource audi;
    public int numOfWave;
    public int Wave;
    public bool canContinue;
    public int num;
    string[] EnemyName = { "Algae", "pig", "CrazyPig", "Goblin", "GoblinElite", "GoblinShaman", "Fish", "BigGoblin" };
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
        num = 0;
        Wave = 0;
        numOfWave = Random.Range(2, 6);
        canContinue = false;
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            if (num <= 0)
            {
                canContinue = true;
            }
            if (canContinue && Wave < numOfWave)
            {
                for (int i = 0; i < 10; i++)
                {
                    int j = Random.Range(0, 8);
                    GameObject newEnemy;
                    newEnemy = (GameObject)Instantiate(Resources.Load("Preset/Enemy/" + EnemyName[j]));
                    newEnemy.GetComponent<EnemyPara>().isElite = true;
                    newEnemy.transform.position = new Vector3(Random.Range(-1.7f, 1.7f) + this.transform.position.x, Random.Range(-1.7f, 1.7f) + this.transform.position.y, 0);
                    newEnemy.GetComponent<EnemyPara>().Room = this.gameObject;
                }
                Wave++;
                num = 10;
                canContinue = false;
            }
            if (Wave == numOfWave && num <= 0)
            {
                state = 2;
            }
        }
        if (state == 2)
        {
            door.SetActive(false);
            audi.Play();
            state = 3;
            GameObject newEnemy;
            newEnemy = (GameObject)Instantiate(Resources.Load("Preset/Back/EnergyChest"));
            newEnemy.transform.position = new Vector3(Random.Range(-1.7f, 1.7f) + this.transform.position.x, Random.Range(-1.7f, 1.7f) + this.transform.position.y, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && state == 0)
        {
            audi.Play();
            door.SetActive(true);
            state = 1;
            canContinue = true;
        }

    }
}
