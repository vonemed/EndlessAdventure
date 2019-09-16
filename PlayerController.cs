using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    PlayerMovement player; // Model of player
    Interactable interactable;

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
                player.StopFollow();
                player.Move(hit.point);
            }
            if (Physics.Raycast(ray, out hit, 100))
            {
                interactable = hit.transform.GetComponent<Interactable>();

                if (interactable != null)
                {
                    player.StoppingDist(interactable);
                    player.Follow(interactable.transform.position);
                    Debug.Log("This item is Interactable. Woah!");
                    interactable.Focuse(transform);
                }

            }
        }
    }
}
