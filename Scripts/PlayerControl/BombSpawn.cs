using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public GameObject bomb;
    public bool bombAva;

    // Start is called before the first frame update
    void Start()
    {
        bombAva = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && bombAva == true)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            bombAva = false;
        }

        if(GameObject.FindGameObjectsWithTag("PlayerBomb").Length <= 2)
        {
            bombAva = true;
        }        
    }
}
