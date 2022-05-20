using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToGreen1Info : MonoBehaviour
{
    public GameObject titleText;
    public Button startButton2;
    public GameObject startButton1;

    // Start is called before the first frame update
    void Start()
    {
        startButton2.GetComponent<Button>();
        startButton2.onClick.AddListener(BeginGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BeginGame()
    {
        titleText.SetActive(false);
        gameObject.SetActive(false);
        startButton1.gameObject.SetActive(false);
        SceneManager.LoadScene(11);
    }
}
