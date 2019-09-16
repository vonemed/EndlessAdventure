using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class EnemyController : MonoBehaviour
{
    EnemyMovement enemyMove;
    EnemyInteract enemy;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponent<EnemyMovement>();
        enemy = GetComponent<EnemyInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.chasing)
        {
            enemyMove.followPlayer(player);
        }
    }
}
