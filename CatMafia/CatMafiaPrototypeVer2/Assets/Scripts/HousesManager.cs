using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesManager : MonoBehaviour
{
    //Variables

    //Spawning
    public Transform resetPoint, startPoint;
    public int speed;

    //Spawn Customers
    public Transform[] customerSpawnPoints;
    public GameObject customer;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn First Customer
        int location = Random.Range(0, customerSpawnPoints.Length);
        Instantiate(customer, customerSpawnPoints[location].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        ResetHouse();
    }

    //Respawn House & Customer Spawn
    void ResetHouse()
    {
        if(transform.position.x < resetPoint.position.x)
        {
            //Respawn House
            transform.position = new Vector2(startPoint.position.x, transform.position.y);

            //Respawn Customer
            int location = Random.Range(0, customerSpawnPoints.Length);
            Instantiate(customer, customerSpawnPoints[location].position, Quaternion.identity);
        }
    }
}
