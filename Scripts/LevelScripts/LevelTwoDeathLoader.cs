using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoDeathLoader : BaseDeathLoader
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
            StartCoroutine(RestartMission());
            Instantiate(deathSound, transform.position, transform.rotation);
        }
        if (lifeCounter.lives <= 0 && dead == true)
        {            
            StartCoroutine(GameIsOver());
            Instantiate(gameOverSound, transform.position, transform.rotation);
        }
    }

    IEnumerator RestartMission()
    {
        yield return new WaitForSeconds(2);
        lifeCounter.lives = lifeCounter.lives - 1;
        SceneManager.LoadScene(3);

    }

    IEnumerator GameIsOver()
    {
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene(0);
    }

}
