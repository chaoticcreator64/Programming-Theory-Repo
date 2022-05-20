using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMission4 : ToMission
{
    public override void Start()
    {
        StartCoroutine(GoToMissionFour());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GoToMissionFour()
    {
        tankLives.SetActive(false);
        missionText.SetActive(false);
        enemyNumber.SetActive(false);


        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(startingSound);
        banner1.SetActive(true);
        banner2.SetActive(true);
        banner3.SetActive(true);
        background.SetActive(true);
        tankLives.SetActive(true);
        missionText.SetActive(true);
        enemyNumber.SetActive(true);


        yield return new WaitForSeconds(2);
        tankLives.SetActive(false);
        missionText.SetActive(false);
        enemyNumber.SetActive(false);


        yield return new WaitForSeconds(.2f);
        banner1.SetActive(false);
        banner2.SetActive(false);
        banner3.SetActive(false);
        background.SetActive(false);

        yield return new WaitForSeconds(.4f);
        SceneManager.LoadScene(8);
    }
}
