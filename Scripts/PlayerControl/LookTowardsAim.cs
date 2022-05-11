using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsAim : MonoBehaviour
{
    public GameObject aimLoc;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(aimLoc.transform.position);
    }
}
