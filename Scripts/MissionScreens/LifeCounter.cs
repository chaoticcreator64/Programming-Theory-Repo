using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public BaseDeathLoader baseDeathLoader;
    public float lives;
    public GameObject thisObject;

    // Start is called before the first frame update
    void Start()
    {        
        lives = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            lives = 3;
        }
    }

    
}
