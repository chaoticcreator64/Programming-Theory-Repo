using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "StrayBullet";
        StartCoroutine(BulletChange());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Rocket") || other.gameObject.CompareTag("PlayerBullet") ||
            other.gameObject.CompareTag("StrayBullet") || other.gameObject.CompareTag("StrayRocket"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("BWall"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BulletChange()
    {
        yield return new WaitForSeconds(.2f);
        gameObject.tag = "Bullet";
    }
}
