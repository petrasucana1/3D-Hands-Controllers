using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandGrabController : MonoBehaviour
{
    private Animator AnimatorComponent { get; set; }
    private XRRayInteractor parentInteractor;
    private bool isGrabbing = false;
    private List<IXRActivateInteractable> targets = new();

    public Vector3 rotationAngle = Vector3.zero;

    private void Start()
    {
        parentInteractor = transform.parent.gameObject.GetComponent<XRRayInteractor>();
        AnimatorComponent = GetComponent<Animator>();
    }

    public void PerformGrab()
    {
        if (!isGrabbing)
        {
            AnimatorComponent.SetTrigger("Grab");
            transform.Rotate(rotationAngle);
            isGrabbing = true;
        }
    }

    public void ReleaseGrab()
    {
        if (isGrabbing)
        {
            AnimatorComponent.SetTrigger("GrabbingToIdleTrigger");
            transform.Rotate(-rotationAngle);
            isGrabbing = false;
        }
    }

    private void FixedUpdate()
    {
        targets.Clear();
        parentInteractor.GetActivateTargets(targets);
        foreach (var target in targets)
        {
            Debug.Log(target);
        }
        
    }

    public void PerformHappyHands()
    {
        AnimatorComponent.SetTrigger("Trigger");
    }
}