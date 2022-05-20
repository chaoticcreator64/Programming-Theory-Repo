using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(GoToTitle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
