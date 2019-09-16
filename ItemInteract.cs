using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : Interactable
{
    public override void Interaction()
    {
        base.Interaction();

        Destroy(gameObject);
        Debug.Log("Item is destroyed!");
    }
}
