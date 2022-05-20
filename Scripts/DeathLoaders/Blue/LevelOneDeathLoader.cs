using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneDeathLoader : BaseDeathLoader
{
    
    
    public override void Start()
    {
        dead = false;
        gameIsOver = false;        
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
        if (lifeCounter.lives >= 1 && dead == true)
        {            
            gameIsOver = true;
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
        yield return new WaitForSeconds(2f);
        lifeCounter.lives = lifeCounter.lives - 1;
        dead = false;
        SceneManager.LoadScene(1);

    }

    IEnumerator GameIsOver()
    {
        if (dontInstantiate == false)
        {
            Instantiate(deathSound);
            Destroy(beginAudio);
            dontInstantiate = true;
        }
        yield return new WaitForSeconds(2.2f);
        dead = false;
        SceneManager.LoadScene(0);
    }
}
