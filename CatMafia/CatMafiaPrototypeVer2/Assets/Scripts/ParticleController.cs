using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    //Variables
    ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireShot();
        }
    }

    public void FireShot()
    {
        ps.Play();
    }


    private void OnParticleCollision(GameObject other)
    {
        //When the particle hits a surface


    }
}
