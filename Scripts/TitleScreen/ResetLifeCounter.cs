using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLifeCounter : MonoBehaviour
{
    public LifeCounter counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("LifeCounter").GetComponent<LifeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter.isActiveAndEnabled == true)
        {
            counter.lives = 3;
        }
    }
}
