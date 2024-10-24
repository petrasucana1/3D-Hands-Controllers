using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableObject : MonoBehaviour
{
    private XRGrabInteractable interactable;
    private List<HandGrabController> previousHands, activeHands;

    void Start()
    {
        previousHands = new();
        activeHands = new();
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void FixedUpdate()
    {
        foreach (var interactor in interactable.interactorsSelecting)
        {
            if (interactor is not XRRayInteractor)
            {
                Debug.LogError("Not XRRayInteractor");
                continue;
            }
            if (!(interactor as XRRayInteractor).TryGetComponent<ActionBasedController>(out var acb))
            {
                continue;
            }
            if (!(acb.model.TryGetComponent<HandGrabController>(out var handGrabController)))
            {
                continue;
            }
            activeHands.Add(handGrabController);
            handGrabController.PerformGrab();
        }

        foreach (var hand in previousHands)
        {
            if (!activeHands.Contains(hand)) {
                hand.ReleaseGrab();
            }
        }
        previousHands = activeHands;
        activeHands = new();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
