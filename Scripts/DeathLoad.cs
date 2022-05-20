using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathLoad : MonoBehaviour
{
    private GameObject player;

    public BaseDeathLoader deathLoader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
        if (player == null)
        {
            deathLoader.dead = true;
        }
    }
}
