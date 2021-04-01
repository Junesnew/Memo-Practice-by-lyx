using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 6;
    public int shield = 6;
    public int energy = 200;
    enum Weapon { gun,sword,bow,staff};
    Weapon mainWeapon, viceWeapon;

    // Start is called before the first frame update
    void Start()
    {
        life = 6;
        shield = 6;
        energy = 200;
        mainWeapon =Weapon.gun;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
}
