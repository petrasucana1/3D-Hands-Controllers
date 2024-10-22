using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    private Vector3 startPos;
    private static HitManager hitManager;
    private Rigidbody rb;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        if (hitManager == null)
        {
            hitManager = FindObjectOfType<HitManager>();
        }
    }

    public void ResetPosition()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (!collision.transform.CompareTag("Club"))
        {
            return;
        }

        Debug.Log("Moving ball");
        hitManager.IncremenentHits();
        var direction = collision.transform.TransformDirection(Vector3.right);
        rb.velocity = Vector3.zero;
        float force = .16f;
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
}
