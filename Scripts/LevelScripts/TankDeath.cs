using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopExplosion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StopExplosion()
    {
        yield return new WaitForSeconds(.7f);
        Destroy(gameObject);
    }
}
