using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour
{
    private LifeCounter lifeCounter;
    // Start is called before the first frame update
    void Start()
    {
        lifeCounter = GameObject.FindGameObjectWithTag("LifeCounter").GetComponent<LifeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeCounter.lives <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
