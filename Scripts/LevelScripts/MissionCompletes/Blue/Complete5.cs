using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete5 : MissionComplete
{
    public bool dontInstantiate;
    public GameObject resultsScreen;
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
        yield return new WaitForSeconds(4);
        Destroy(completeRound);
        resultsScreen.SetActive(true);
        
    }
}
