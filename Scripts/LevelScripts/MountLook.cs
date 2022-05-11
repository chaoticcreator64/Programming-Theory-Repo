using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountLook : MonoBehaviour
{
    public EnemyTanks enemyTanks;
    public Transform playerTank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTanks.playerInSightRange && enemyTanks.playerInAttackRange)
        {
            transform.LookAt(playerTank);
        }
    }
}
