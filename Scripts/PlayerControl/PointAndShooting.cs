using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShooting : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;

    public float bulletSpeed = 60.0f;

    private Vector3 target;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -transform.position.z));
        crosshairs.transform.position = new Vector3(target.x, target.y, target.z);
    }
}
