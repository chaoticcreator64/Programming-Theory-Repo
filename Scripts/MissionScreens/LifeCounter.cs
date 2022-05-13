using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public BaseDeathLoader baseDeathLoader;
    public float lives;
    public AudioSource audioSource;
    public AudioClip gameOverSound;
    private float lifeDecrease = -.5f;    

    // Start is called before the first frame update
    void Start()
    {       
        lifeDecrease = -.5f;
        lives = 3;        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2)|| SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4)
                || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(6) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(8)
                || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(10) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(12)
                || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(14))
        {
            if (lives == 0)
            {
                baseDeathLoader.gameIsOver = true;
            }
            if (baseDeathLoader.dead == true)
            {
                StartCoroutine(LifeDecrease());
            }            
        }
        else
        {
            
        }
    }

    IEnumerator LifeDecrease()
    {
        yield return new WaitForSeconds(.0000001f);
        lives = lives + lifeDecrease;
        yield return new WaitForSeconds(.0000001f);
        lifeDecrease = 0;
        
        StopCoroutine(LifeDecrease());
    }
}
