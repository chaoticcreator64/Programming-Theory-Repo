using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    private BoxCollider boxCollider;
    public bool explosion;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(StopExplosion());
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(6, 6, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.CompareTag("BWall"))
        {
            Destroy(other.gameObject);
        }
        
    }
    private void OnCollisionStay(Collision other1)
    {
        if (other1.gameObject.CompareTag("BWall"))
        {
            Destroy(other1.gameObject);
        }
    }
    IEnumerator StopExplosion()
    {        
        yield return new WaitForSeconds(.8f);
        
        Destroy(gameObject);
    }
}
