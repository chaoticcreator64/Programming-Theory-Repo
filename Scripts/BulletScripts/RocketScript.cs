using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    
    public GameObject particle;

    public LayerMask collisionMask;

    public Transform rocketT;

    public bool wallBounce;
    public float wallBounceNum;
    public float rotationSpeed;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        particle.gameObject.SetActive(true);
        
        gameObject.tag = "StrayRocket";

        StartCoroutine(RocketChange());
        wallBounceNum = 0;
        wallBounce = true;
        rotationSpeed = 4000;
        speed = 2;
        StartCoroutine(RocketChange());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, speed + .1f, collisionMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }

        if (wallBounceNum >= 2)
        {
            wallBounce = false;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Rocket") || other.gameObject.CompareTag("PlayerBullet") ||
            other.gameObject.CompareTag("StrayBullet") || other.gameObject.CompareTag("StrayRocket"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall") && wallBounce == true || other.gameObject.CompareTag("BWall") && wallBounce == true)
        {
            wallBounceNum = wallBounceNum + 1;
        }
        if (other.gameObject.CompareTag("Wall") && wallBounce == false || other.gameObject.CompareTag("BWall") && wallBounce == false)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator RocketChange()
    {
        yield return new WaitForSeconds(.2f);
        gameObject.tag = "Rocket";
    }
}
