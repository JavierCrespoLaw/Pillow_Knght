using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    
    public float rayRange = 5f;
    Vector2 groundRays;

    public bool grounded = false;
    Rigidbody2D rb;
    Animator anim;
    Health H;


     public AudioSource swing;
    public AudioSource Squeak;
    public AudioSource Take;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        H = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!H.dead)
        {
            Move();
            Jump();


            if (Input.GetButtonDown("Fire1") && grounded)
            {
                anim.Play("Attack");
                anim.SetBool("Attacking", true);
            }
        }
    }

    public void Move()
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
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded && !anim.GetBool("Attacking"))
        {
            grounded = false;
            anim.SetBool("Grounded", false);
            anim.SetBool("Jumping", true);
            Squeak.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
          groundRays = new Vector2 (transform.position.x , transform.position.y -0.5f);
          RaycastHit2D hitGround = Physics2D.Raycast(groundRays, -Vector2.up * rayRange);
          if (hitGround.collider != null && hitGround.collider.tag=="Floor" && rb.velocity.y == 0)
          {
            grounded = true;
            anim.SetBool("Grounded", grounded);
          }
    }

    public void collected()
    {
        Take.Play();
    }

    public void Swing()
    {
        swing.Play();
    }
    public void Reset()
    {
        anim.SetBool("Attacking", false);
        anim.SetBool("Jumping", false);
    }
}
