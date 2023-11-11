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
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("Moving", true);
            transform.position += Vector3.left * Time.deltaTime * speed;

        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {

            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("Moving", true);
            transform.position += Vector3.right * Time.deltaTime * speed;

        }
        else
        {
            anim.SetBool("Moving", false);
        }

        if(Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            anim.SetBool("Grounded", false);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
            anim.SetBool("Grounded", grounded);
        }
    }
}
