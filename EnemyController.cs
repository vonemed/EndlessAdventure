using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class EnemyController : MonoBehaviour
{
    EnemyMovement enemyMove;
    EnemyInteract enemy;
    Combat combat;

    public float detectRadius = 10f;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponent<EnemyMovement>();
        enemy = GetComponent<EnemyInteract>();
        player = PlayerManager.instance.player.transform;
        combat = GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float dist = Vector3.Distance(player.position, transform.position);

            if (dist <= detectRadius)
            {
                enemyMove.followPlayer(player);

                if (dist <= 2f) // If enemy reached stopping distance 
                {
                    Stats playerStats = player.GetComponent<Stats>();

                    if (playerStats != null)
                    {
                        combat.Attack(playerStats);
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
