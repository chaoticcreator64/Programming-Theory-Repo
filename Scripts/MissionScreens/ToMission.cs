using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMission : MonoBehaviour
{    
    public GameObject banner1;
    public GameObject banner2;
    public GameObject banner3;
    public GameObject background;
    public GameObject tankLives;
    public GameObject missionText;
    public GameObject enemyNumber;
    

    public AudioSource audioSource;
    public AudioClip startingSound;


    // Start is called before the first frame update
    public virtual void Start()
    {
        audioSource.PlayOneShot(startingSound);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
}
