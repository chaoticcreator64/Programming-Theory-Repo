using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankExplosion : MonoBehaviour
{
    public ParticleSystem tankExplosion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                    
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Rocket"))
        {
            Instantiate(tankExplosion, transform.position, tankExplosion.transform.rotation);
            Destroy(other.gameObject);
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(.2f);        
        Destroy(gameObject);
    }
}
