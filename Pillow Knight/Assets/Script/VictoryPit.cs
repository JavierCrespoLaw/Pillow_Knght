using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPit : MonoBehaviour
{

    public float gearsNeeded ;

    public bool isUnlocked ;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gearsNeeded <= 0) {
            isUnlocked = true ;
        }

        if (collision.CompareTag("Player") && isUnlocked) {
            SceneManager.LoadScene("Victory");
        }
    }
}
