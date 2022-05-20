using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Green2Complete : MissionComplete
{
    public bool dontInstantiate;
    public GameObject beginAudio;

    // Update is called once per frame
    public override void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {

            StartCoroutine(LoadNewMission());
            Destroy(beginAudio);
        }
    }

    IEnumerator LoadNewMission()
    {
        levelComplete = true;
        if (dontInstantiate == false)
        {
            Instantiate(completeRound, transform.position, transform.rotation);
            dontInstantiate = true;
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(15);
    }
}

