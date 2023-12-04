using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearScript : MonoBehaviour
{

    public VictoryPit vp ;
    public GameObject p;


    public void OnTriggerEnter2D(Collider2D c) {
        
        if (c.CompareTag("Player")) {
            p.GetComponent<Movement>().collected();
            vp.gearsNeeded -= 1 ;
            Destroy(this.gameObject) ;
        }
    }
}
