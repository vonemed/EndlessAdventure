using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    PlayerMovement player; // Model of player
    Interactable interactable; // An interactable on which player is currently focused

    public LayerMask ground;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        player = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, ground))
            {
                player.Move(hit.point);
                resetFocus(); 
            }
            if (Physics.Raycast(ray, out hit, 100))
            {
                interactable = hit.transform.GetComponent<Interactable>();

                if (interactable != null)
                {
                    setFocus(interactable);
                }

            }
        }
    }

    void setFocus(Interactable _interactable)
    {
        // Set focus for player follow it
        interactable = _interactable;
        interactable.Focuse(player.transform);
        player.Follow(_interactable);

        Debug.Log("This item is Interactable. Woah!");

    }

    void resetFocus()
    {
        if (interactable != null)
        {
            interactable.focused = false;
            interactable = null;
            player.StopFollow();
        }
    }
}
