using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetLifeCounter : MonoBehaviour
{
    public Button beginGame;
    public LifeCounter lifeCounter;
    // Start is called before the first frame update
    void Start()
    {
        beginGame = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        beginGame.onClick.AddListener(ResetLives);
    }

    void ResetLives()
    {
        lifeCounter.lives = 3;
    }
}
