using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class EnemyInteract : Interactable
{
    PlayerManager playerManager;
    Stats selfStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        selfStats = GetComponent<Stats>();
    }

    public override void Interaction()
    {
        base.Interaction();

        Combat playerCombat = playerManager.player.GetComponent<Combat>();

        if (playerCombat != null)
        {
            playerCombat.Attack(selfStats);
        }
    }
}
