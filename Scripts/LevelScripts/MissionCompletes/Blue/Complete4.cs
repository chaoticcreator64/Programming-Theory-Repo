using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete4 : MissionComplete
{
    public bool dontInstantiate;
    public GameObject beginAudio;
    public BaseDeathLoader baseDeathLoad;

    // Update is called once per frame
    public override void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && baseDeathLoad.playerNum >= 1)
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
            Instantiate(completeRound);
            Destroy(beginAudio);
            dontInstantiate = true;
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(7);
    }
}
