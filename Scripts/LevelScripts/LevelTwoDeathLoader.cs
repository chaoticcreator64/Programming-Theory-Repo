using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoDeathLoader : BaseDeathLoader
{

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

    public override void UponDeath()
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
        SceneManager.LoadScene(3);

    }

    IEnumerator GameIsOver()
    {
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene(0);
    }

}
