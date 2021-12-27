using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject otherPortal;
    [SerializeField] private bool isPortalOn = false;

    [SerializeField] private GameObject playerTarget;
    
    public bool IsPortalOn
    {
        set => isPortalOn = value;
        get => isPortalOn;
    }
    private void Awake()
    {
        isPortalOn = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && otherPortal.GetComponent<Portal>().isPortalOn)
        {
            Rigidbody otherRig = other.GetComponent<Rigidbody>();

            Vector3 exitVelocity = otherPortal.transform.forward * otherRig.velocity.magnitude;
            otherRig.velocity = exitVelocity;

            otherRig.transform.localPosition = otherPortal.transform.localPosition + otherPortal.transform.forward * 2;
        }
    }
}
