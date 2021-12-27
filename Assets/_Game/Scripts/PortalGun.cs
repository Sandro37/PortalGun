using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{

    [SerializeField] private GameObject leftPortal;
    [SerializeField] private GameObject rightPortal;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            ThrowPortal(leftPortal);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ThrowPortal(rightPortal);
        }
    }

    private void ThrowPortal(GameObject portal)
    {
        portal.GetComponent<Portal>().IsPortalOn = true;
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            portal.transform.position = hit.point;
            portal.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }
}
