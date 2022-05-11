using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseDeathLoader : MonoBehaviour
{
    public LifeCounter lifeCounter;
    public bool dead;
    public bool gameIsOver;
    public AudioSource audioSource;
    public AudioClip deathSound;
    public float volume;
    public float playerNum;

    // Start is called before the first frame update
    public virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dead = false;
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerNum = GameObject.FindGameObjectsWithTag("Player").Length;
        lifeCounter = GameObject.Find("LifeCounter").GetComponent<LifeCounter>();
        if (playerNum == 0)
        {
            dead = true;
            UponDeath();
        }
    }

    public virtual void UponDeath()
    {
        if (lifeCounter.lives > 0 && dead == true)
        {
            audioSource.PlayOneShot(deathSound);
            StartCoroutine(RestartMission());
        }
        if (lifeCounter.lives <= 0 && dead == true)
        {
            audioSource.PlayOneShot(lifeCounter.gameOverSound);
            StartCoroutine(GameIsOver());
        }        
    }

    IEnumerator RestartMission()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
        
    }

    IEnumerator GameIsOver()
    {
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene(0);
    }
}
