using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public GameObject StartImage, StartButton, Pause, Volume, Load, Save, ContinueG, GameOver, RePlay;
    // Start is called before the first frame update
    void Awake()
    {
        StartImage = GameObject.Find("StartImage");
        StartButton = GameObject.Find("StartButton");
        Pause = GameObject.Find("Pause");
        Volume = GameObject.Find("Volume");
        Load = GameObject.Find("Load");
        Save = GameObject.Find("Save");
        ContinueG = GameObject.Find("Continue");
        GameOver = GameObject.Find("GameOver");
        RePlay= GameObject.Find("RePlay");
    }
    private void Start()
    {
        ContinueGame();
        GameOver.SetActive(false);
        RePlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void start()
    {
        StartImage.SetActive(false);
        StartButton.SetActive(false);
    }
    public void pause()
    {
        Time.timeScale = 0f;
        Pause.SetActive(true);
        ContinueG.SetActive(true);
        Save.SetActive(true);
        Load.SetActive(true);
        Volume.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
        ContinueG.SetActive(false);
        Save.SetActive(false);
        Load.SetActive(false);
        Volume.SetActive(false);
    }
    public void reStart()
    {
        SceneManager.LoadScene("Level1");
        GameObject.Find("SaveLoad").GetComponent<SaveLoad>().level = 1;
        GameObject.Find("SaveLoad").GetComponent<SaveLoad>().mainWeapon = 3;
        GameObject.Find("SaveLoad").GetComponent<SaveLoad>().viceWeapon= -1;
        GameObject.Find("SaveLoad").GetComponent<SaveLoad>().life  = 6;
        GameObject.Find("SaveLoad").GetComponent<SaveLoad>().shield = 6;
        GameObject.Find("SaveLoad").GetComponent<SaveLoad>().energy =200 ;
    }
}
