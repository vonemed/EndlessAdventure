using UnityEngine;

public class ItemInteract : Interactable
{
    public Item item;
    public override void Interaction()
    {
        base.Interaction();

        pickUp();
    }

    public void pickUp()
    {
        Destroy(gameObject);
    }
}
