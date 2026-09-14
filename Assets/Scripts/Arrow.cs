using UnityEngine;
using System;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private Collider coll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            var closestPos = other.ClosestPoint(transform.position);
            transform.position = closestPos - transform.forward * 0.2f;
            transform.SetParent(other.transform);

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            coll.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
