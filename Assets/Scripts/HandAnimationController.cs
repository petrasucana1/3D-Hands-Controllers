using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class HandGrabController : MonoBehaviour
{
    private Animator AnimatorComponent { get; set; }
    private ActionBasedController parentController;
    private bool isGrabbing = false;
    private float happyHandsCooldown = 3f;
    private float timer = 3f;

    public Vector3 rotationAngle = Vector3.zero;

    private void Start()
    {
        parentController = transform.parent.gameObject.GetComponent<ActionBasedController>();
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

    private void Update()
    {
        timer += Time.deltaTime;
        if (!isGrabbing && timer >= happyHandsCooldown && parentController.activateAction.action.IsPressed())
        {
            timer = 0f;
            PerformHappyHands();
        }
    }

    public void PerformHappyHands()
    {
        AnimatorComponent.SetTrigger("Trigger");
    }
}