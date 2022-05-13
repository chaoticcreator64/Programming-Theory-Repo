using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TitleButtonSlide : MonoBehaviour
{
    public GameObject startButton;
    public bool titleButtonSliding;
    public Button startButtoninteractive;

    // Start is called before the first frame update
    void Start()
    {
        titleButtonSliding = false;
        startButtoninteractive.interactable = false;
        StartCoroutine(ButtonSliding());
    }

    // Update is called once per frame
    void Update()
    {
        if (titleButtonSliding == true)
        {
            startButtoninteractive.interactable = false;
            transform.Translate(Vector3.right * 1000 * Time.deltaTime);
        }
        if (titleButtonSliding == false)
        {
            startButtoninteractive.interactable = true;
        }
        if (transform.position.x > 481)
        {
            transform.position = new Vector3(481, transform.position.y, transform.position.z);
            titleButtonSliding = false;
        }
    }

    IEnumerator ButtonSliding()
    {
        yield return new WaitForSeconds(2f);
        titleButtonSliding = true;
        
    }
}
