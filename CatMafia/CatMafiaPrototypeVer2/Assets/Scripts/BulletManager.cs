using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //Variables

    //GameObjects
    public GameObject player;

    //Movement
    public float speed;
    public Rigidbody2D rb;
    public Transform minX, maxX, minY, maxY;

    //Bullet Type
    public bool milkType;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = GameObject.Find("MafiaCat").GetComponent<PlayerManager>().firePoint.right * speed;
        //gameObject.transform.LookAt(Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        CheckBoundaries();
    }

    //Check Boundaries
    void CheckBoundaries()
    {
        if(transform.position.x < minX.position.x)
        {
            Destroy(gameObject);
        } 
        else if (transform.position.x > maxX.position.x)
        {
            Destroy(gameObject);
        } 
        else if (transform.position.y < minY.position.y)
        {
            Destroy(gameObject);
        } 
        else if (transform.position.y > maxY.position.y)
        {
            Destroy(gameObject);
        }
    }

    //Collife w/ Enemy/Customer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (milkType) //Good Milk
        {
            if(collision.CompareTag("Customer"))
            {
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash += points;
                Destroy(gameObject);
            }
            else if(collision.CompareTag("Enemy"))
            {
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash -= points;
                Destroy(gameObject);
            }
        }
        else //Rotten Milk
        {
            if (collision.CompareTag("Customer"))
            {
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash -= points;
                Destroy(gameObject);
            }
            else if (collision.CompareTag("Enemy"))
            {
                GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash += points;
                Destroy(gameObject);
            }
        }
    }
}
