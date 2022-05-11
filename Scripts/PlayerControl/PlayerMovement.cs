using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float pSpeed = 5f;
    public AudioSource movementSounds;
    public AudioClip engineSound;
    public float horizontalAxis;
    public float verticalAxis;
    public GameObject playerCharacter;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        TankMovement();
    }

    void TankMovement()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        if (horizontalAxis != 0 && verticalAxis != 0)
        {
            pSpeed = 4.0f;
        }
        else
        {
            pSpeed = 5.0f;
        }

        transform.Translate(transform.right * -horizontalAxis * Time.deltaTime * pSpeed);
        transform.Translate(transform.forward * verticalAxis * Time.deltaTime * pSpeed);

        Vector3 moveDirection = new Vector3(horizontalAxis, 0, verticalAxis);
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, newRotation, Time.deltaTime * 8);
        }
    }
}
