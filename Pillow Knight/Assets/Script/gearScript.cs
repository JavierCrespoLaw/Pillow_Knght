using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearScript : MonoBehaviour
{

    public VictoryPit vp ;



    public void OnTriggerEnter2D(Collider2D c) {
        
        if (c.CompareTag("Player")) {
            vp.gearsNeeded -= 1 ;
            Destroy(this.gameObject) ;
        }
    }
}
