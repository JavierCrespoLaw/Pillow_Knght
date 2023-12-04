using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPit : MonoBehaviour
{

    public float gearsNeeded ;
    public bool isUnlocked ;
    public Sprite s;
    public SpriteRenderer sp;

    void Update()
    {
        if (gearsNeeded <= 0)
        {
            sp.sprite = s;
            isUnlocked = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && isUnlocked) {
            SceneManager.LoadScene("Victory");
        }
    }
}
