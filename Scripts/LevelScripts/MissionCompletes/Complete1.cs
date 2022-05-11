using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete1 : MissionComplete
{
    // Update is called once per frame
    public override void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            audioSource.PlayOneShot(missionComplete);
            StartCoroutine(LoadNewMission());
            Destroy(beginingLevel.beginAudio);
        }
    }

    IEnumerator LoadNewMission()
    {
        levelComplete = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(5);
    }
}
