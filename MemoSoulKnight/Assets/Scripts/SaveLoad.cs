using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{

    public int mainWeapon, viceWeapon;
    public int life, shield, energy;
    public int level;
    // Start is called before the first frame update
    private void Awake()
    {
        level = 1;
        mainWeapon = 3;
        viceWeapon = -1;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
