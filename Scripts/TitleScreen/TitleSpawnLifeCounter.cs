using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSpawnLifeCounter : MonoBehaviour
{
    public GameObject lifeCounter;
    public float stopMulti;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stopMulti = GameObject.FindGameObjectsWithTag("LifeCounter").Length;
        if (stopMulti >= 1)
        {
            
        }
        if (stopMulti < 1)
        {
            Instantiate(lifeCounter);
        }
    }
}
