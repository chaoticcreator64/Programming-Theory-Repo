using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private GameObject bomb;
    private BombAboutToExplode toExplode;
    private float maxDist = 4;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bomb = GameObject.FindGameObjectWithTag("Bomb");
        toExplode = GameObject.FindGameObjectWithTag("Bomb").GetComponent<BombAboutToExplode>();
        dist = Vector3.Distance(bomb.transform.position, transform.position);
        if (maxDist >= dist && toExplode.explosion == true)
        {
            Destroy(gameObject);
        }
    }

    
}
