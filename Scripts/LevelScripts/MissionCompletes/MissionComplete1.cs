using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionComplete : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip missionComplete;
    public bool levelComplete;

    public BeginingLevel beginingLevel;

    // Start is called before the first frame update
    void Start()
    {
        beginingLevel = GameObject.Find("MainCamera").GetComponent<BeginingLevel>();
    }

    // Update is called once per frame
    public virtual void Update()
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
        SceneManager.LoadScene(3);
    }
}
