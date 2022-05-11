using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TitleSlide : MonoBehaviour
{
    public GameObject titleText;
    public bool titleSliding;

    // Start is called before the first frame update
    void Start()
    {
        titleSliding = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (titleSliding == true)
        {
            transform.Translate(Vector3.right * 1000 * Time.deltaTime);            
        }
        if (transform.position.x > 402)
        {
            transform.position = new Vector3(402, transform.position.y, transform.position.z);
            titleSliding = false;
        }
    }
}
