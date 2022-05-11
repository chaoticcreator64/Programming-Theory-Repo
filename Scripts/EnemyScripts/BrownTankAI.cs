using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownTankAI : MonoBehaviour
{
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
