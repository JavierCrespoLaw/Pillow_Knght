using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public float maxHealth ;
    float health ;
    public bool dead = false ;


    Rigidbody2D rb;
    Animator anim;

    public AudioSource Squeak;

    public void takeDamage() {
        if (health > 1) {
            health -= 1 ;
        }
        else {
            dead = true ;
        }
    }

    public void Death()
    {
        Squeak.Play();
        anim.SetBool("Dead", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth ;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) {
            
            Death() ;
        }
    }


    void ChangeScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
