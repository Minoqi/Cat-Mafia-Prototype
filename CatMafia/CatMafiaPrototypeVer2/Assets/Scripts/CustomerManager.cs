using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    //Variables
    public Transform endPoint;
    public int worth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        transform.Translate(Vector2.left * GameObject.Find("House").GetComponent<HousesManager>().speed * Time.deltaTime);

        OutOfBounds();
    }

    //Destroy at Boundaries
    void OutOfBounds()
    {
        if(transform.position.x < endPoint.position.x)
        {
            GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash -= worth;
            Destroy(gameObject);
        }
    }

    //Milk Received
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Milk"))
        {
            GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash += worth;
            Destroy(gameObject);
        } 
        else if(collision.CompareTag("RottenMilk"))
        {
            GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash -= worth;
        }
    }
}
