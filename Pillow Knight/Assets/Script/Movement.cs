using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;


    public bool grounded = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") <0)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }

        if(Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }
}
