using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    Vector2 groundRays, LSide , RSide;
    GameObject floor = null;
    Boolean change;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        groundRays = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RaycastHit2D hitGround = Physics2D.Raycast(groundRays, -Vector2.up * 1f);
        if (hitGround.collider != null && hitGround.collider.tag == "Floor")
        {
            floor = hitGround.collider.gameObject;
        }

  
        LSide = new Vector2(floor.transform.position.x - (floor.GetComponent<SpriteRenderer>().size.x) / 2 , transform.position.y);
        RSide = new Vector2(floor.transform.position.x + (floor.GetComponent<SpriteRenderer>().size.x) / 2 , transform.position.y);

        Debug.Log(LSide);
        Debug.Log(RSide);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (!change)
        {
            transform.position = Vector2.MoveTowards(transform.position, RSide, step);
            if (transform.position.x == RSide.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                change = !change;
            }
        }


        if (change)
        {
            transform.position = Vector2.MoveTowards(transform.position, LSide, step);
            if (transform.position.x == LSide.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                change = !change;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponent<Health>().takeDamage();
          
    }
}
