using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{

    public float gearsNeeded ;

    public bool isUnlocked ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gearsNeeded <= 0) {
            isUnlocked = true ;
            Destroy(gameObject) ;
        }
    }
}
