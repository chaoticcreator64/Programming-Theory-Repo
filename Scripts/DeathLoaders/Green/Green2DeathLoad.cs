using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Green2DeathLoad : BaseDeathLoader
{
    void Awake()
    {
        dead = false;
    }
    public override void Update()
    {
        playerNum = GameObject.FindGameObjectsWithTag("Player").Length;
        lifeCounter = GameObject.FindGameObjectWithTag("LifeCounter").GetComponent<LifeCounter>();

        if (playerNum == 0)
        {
            dead = true;
            UponDeath();
        }
    }

    public override void UponDeath()
    {
        if (lifeCounter.lives > 0 && dead == true)
        {
            StartCoroutine(RestartMission());
        }
        if (lifeCounter.lives <= 0 && dead == true)
        {
            StartCoroutine(GameIsOver());
        }
    }

    IEnumerator RestartMission()
    {
        if (dontInstantiate == false)
        {
            Instantiate(deathSound);
            Destroy(beginAudio);
            dontInstantiate = true;
        }
        yield return new WaitForSeconds(2);
        lifeCounter.lives = lifeCounter.lives - 1;
        SceneManager.LoadScene(13);

    }

    IEnumerator GameIsOver()
    {
        if (dontInstantiate == false)
        {
            Instantiate(gameOverSound);
            Destroy(beginAudio);
            dontInstantiate = true;
        }
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene(0);
    }
}
