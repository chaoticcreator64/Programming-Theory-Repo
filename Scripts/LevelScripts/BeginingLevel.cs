using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginingLevel : MonoBehaviour
{
    public AudioSource audioSource;
    private bool stopTime;
    public BaseDeathLoader baseDeathLoader;
    public MissionComplete missionComplete;

    public GameObject beginAudio;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        stopTime = true;
        beginAudio = GameObject.Find("BeginAudio").GetComponent<GameObject>();
        missionComplete = GameObject.Find("GameManager").GetComponent<MissionComplete>();
        StartCoroutine(StopAndGo());        
    }

    // Update is called once per frame
    void Update()
    {
        baseDeathLoader = GameObject.Find("GameManager").GetComponent<BaseDeathLoader>();
        if (baseDeathLoader.dead == true)
        {           
            Destroy(beginAudio);
        }
        if (missionComplete.levelComplete == true)
        {
            Destroy(beginAudio);
        }
    }

    IEnumerator StopAndGo()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        Time.timeScale = 1;
    }
}
