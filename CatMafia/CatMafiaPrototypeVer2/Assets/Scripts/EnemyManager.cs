using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Variables
    public Transform endPoint;
    public int worth, dmg;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteOptions;

    // Start is called before the first frame update
    void Start()
    {
        //Choose Random Enemy Sprite
        int randomSprite = Random.Range(0, spriteOptions.Length);
        spriteRenderer.sprite = spriteOptions[randomSprite];
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
        if (transform.position.x < endPoint.position.x)
        {
            GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash -= worth;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash -= worth;
            GameObject.Find("MafiaCat").GetComponent<PlayerManager>().health -= dmg;
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Milk"))
        {
            GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash -= worth;
        }
        else if(collision.CompareTag("RottenMilk"))
        {
            GameObject.Find("MafiaCat").GetComponent<PlayerManager>().cash += worth;
            Destroy(gameObject);
        }
    }
}
