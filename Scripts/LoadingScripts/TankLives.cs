using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankLives : MonoBehaviour
{   
    public LifeCounter lifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        
        lifeCounter = GameObject.Find("LifeCounter").GetComponent<LifeCounter>();        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Tanks:" + lifeCounter.lives;
    }
}
