using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringShot : MonoBehaviour
{        
    public Rigidbody bullet;
    public float power = 1500f;    
    
    public bool firingLimit;

    void Start()
    {
        firingLimit = true;
    }

    // Update is called once per frame
    void Update()
    {         
        if (Input.GetKeyDown(KeyCode.Mouse0) && firingLimit == true)
        {            
            Rigidbody instance = Instantiate(bullet, transform.position, transform.rotation);            
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            instance.AddForce(fwd * power);
        }
        if (GameObject.FindGameObjectsWithTag("Bullet").Length >= 5)
        {
            firingLimit = false;
        }
        if (GameObject.FindGameObjectsWithTag("Bullet").Length < 5)
        {
            firingLimit = true;
        }
    }
}
