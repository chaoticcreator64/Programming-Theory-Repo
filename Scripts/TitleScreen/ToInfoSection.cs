using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToInfoSection : MonoBehaviour
{
    public GameObject titleText;
    public Button startButton1;
    public GameObject startButton2;

    // Start is called before the first frame update
    void Start()
    {
        startButton1.GetComponent<Button>();
        startButton1.onClick.AddListener(BeginGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BeginGame()
    {
        titleText.SetActive(false);
        gameObject.SetActive(false);
        startButton2.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
