using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //Variables

    //Shooting
    public GameObject milkBullet, rottenMilkBullet;
    public Transform firePoint;
    public Vector2 lookDirection;
    public float lookAngle;
    public bool particleGun;

    //Stats
    public int health;
    public int cash;
    public int milkAmmo, rottenMilkAmmo;

    //UI
    public Text healthUI, cashUI, milkAmmoUI, rottenMlkAmmoUI;

    // Start is called before the first frame update
    void Start()
    {
        particleGun = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShootManager();
        UpdateUI();
        TestControls();
    }

    //Shoot Bullet
    void ShootManager()
    {
        if(Input.GetMouseButtonDown(0) && milkAmmo > 0) //Good Milk
        {
            lookDirection = Camera.main.WorldToScreenPoint(Input.mousePosition);
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

            Instantiate(milkBullet, firePoint.position, firePoint.rotation);
            milkAmmo--;
        }
        else if(Input.GetMouseButtonDown(1) && rottenMilkAmmo > 0) //Rotten Milk
        {
            lookDirection = Camera.main.WorldToScreenPoint(Input.mousePosition);
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

            Instantiate(rottenMilkBullet, firePoint.position, firePoint.rotation);
            rottenMilkAmmo--;
        }
    }

    //Temp Controls
    void TestControls()
    {
        //Add Ammo
        if(Input.GetKeyDown(KeyCode.A))
        {
            milkAmmo += 10;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            rottenMilkAmmo += 10;
        }
    }

    //Update UI
    void UpdateUI()
    {
        healthUI.text = health.ToString() + "/100";
        cashUI.text = "$" + cash.ToString();
        milkAmmoUI.text = milkAmmo.ToString();
        rottenMlkAmmoUI.text = rottenMilkAmmo.ToString();
    }
}
