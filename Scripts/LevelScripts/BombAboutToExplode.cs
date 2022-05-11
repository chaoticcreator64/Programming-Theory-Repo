using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BombAboutToExplode : MonoBehaviour
{
    public GameObject bomb;
    public Renderer bombRender;
    private Color yellow;
    private Color red;
    public ParticleSystem explosionParticle;

    public bool explosion;
    public bool backFire;

    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Awake()
    {
        bombRender = bomb.GetComponent<Renderer>();
        yellow = new Color(255, 241, 0);
        red = new Color(255, 45, 0);
        StartCoroutine(AboutTo());
        explosion = false;
        backFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (explosion == true)
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            
            explosion = false;            
            StartCoroutine(DestroyObject());
        }

    }

    IEnumerator AboutTo()
    {
        Update();
        yield return new WaitForSeconds(5);
        bombRender.material.SetColor("_Color", yellow);
        backFire = true;
        yield return new WaitForSeconds(1);
        bombRender.material.SetColor("_Color", red);
        yield return new WaitForSeconds(1);
        bombRender.material.SetColor("_Color", yellow);
        yield return new WaitForSeconds(.5f);
        bombRender.material.SetColor("_Color", red);
        yield return new WaitForSeconds(.5f);
        bombRender.material.SetColor("_Color", yellow);
        yield return new WaitForSeconds(.3f);
        bombRender.material.SetColor("_Color", red);
        yield return new WaitForSeconds(.3f);
        bombRender.material.SetColor("_Color", yellow);
        yield return new WaitForSeconds(.2f);
        bombRender.material.SetColor("_Color", red);
        yield return new WaitForSeconds(.2f);
        bombRender.material.SetColor("_Color", yellow);
        yield return new WaitForSeconds(.1f);
        bombRender.material.SetColor("_Color", red);
        yield return new WaitForSeconds(.1f);
        bombRender.material.SetColor("_Color", yellow);
        yield return new WaitForSeconds(.05f);
        bombRender.material.SetColor("_Color", red);
        explosion = true;
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Rocket"))
        {
            explosion = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player") && backFire == true)
        {
            explosion = true;           
        }        
    }
}
