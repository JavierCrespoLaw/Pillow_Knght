using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public float maxHealth ;
    float health ;
    public bool dead = false ;
    float timer = 0 ;

    Rigidbody2D rb;
    Animator anim;

    public void takeDamage(float damage) {
        if (health > 1) {
            health -= 1 ;
        }
        else {
            dead = true ;
        }
    }

    public void Death() {
        anim.SetBool("Dead", true) ;
        timer += Time.deltaTime ;
            if (timer > 2) {
                SceneManager.LoadScene("GameOver");
        }
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
}
