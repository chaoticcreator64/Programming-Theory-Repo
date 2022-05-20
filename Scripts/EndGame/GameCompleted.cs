using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleted: MonoBehaviour
{
    public GameObject blackening;
    public GameObject lifeTracker;
    public GameObject gameComplete;
    public GameObject toTitleButton;
    public AudioSource audioSource;
    public AudioClip resultsSounds;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaceUI());        
    }

    IEnumerator PlaceUI()
    {
        audioSource.PlayOneShot(resultsSounds);
        lifeTracker.SetActive(false);
        yield return new WaitForSeconds(.5f);        
        blackening.SetActive(true);
        yield return new WaitForSeconds(2);
        gameComplete.SetActive(true);
        yield return new WaitForSeconds(4);
        toTitleButton.SetActive(true);        
    }
}
