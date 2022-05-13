using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneDeathLoader : BaseDeathLoader
{    

    void Update()
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
            Instantiate(deathSound, transform.position, transform.rotation);
            StartCoroutine(RestartMission());
        }
        if (lifeCounter.lives <= 0 && dead == true)
        {
            Instantiate(gameOverSound, transform.position, transform.rotation);
            StartCoroutine(GameIsOver());
        }
    }

    IEnumerator RestartMission()
    {        
        yield return new WaitForSeconds(2);
        lifeCounter.lives = lifeCounter.lives - 1;
        SceneManager.LoadScene(1);

    }

    IEnumerator GameIsOver()
    {
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene(0);
    }

}
