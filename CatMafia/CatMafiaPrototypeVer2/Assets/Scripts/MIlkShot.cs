using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIlkShot : MonoBehaviour
{

    ParticleSystem ps;
    public int points;
    public float fillInterval;
    public bool goodMilk;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
    }


    private void OnParticleCollision(GameObject other)
    {
        //Activate on particle hit
        if (goodMilk) //Good Milk
        {
            if (other.CompareTag("Customer"))
            {
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash += points;
            }
            else if (other.CompareTag("Enemy"))
            {
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().health -= 10;
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash -= points;
            }
        }
        else //Rotten Milk
        {
            if (other.CompareTag("Customer"))
            {
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().health -= 10;
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash -= points;
            }
            else if (other.CompareTag("Enemy"))
            {
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().health -= 10;
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash += points;
            }
        }
    }

}

