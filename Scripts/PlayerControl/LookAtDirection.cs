using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDirection : MonoBehaviour
{
    [SerializeField] public Camera aimCamera;

    private void Update()
    {
        Ray ray = aimCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }
    }
}
