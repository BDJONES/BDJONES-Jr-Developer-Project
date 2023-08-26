using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    //private Rigidbody projectileRb;
    private float range = 20f;
    private float damage = 10f;
    public Camera playerCamera;
    private GameObject selectedObject;
    private SizableObject sizable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.E) && sizable != null && sizable.isSelected)
        {
            sizable.Grow(selectedObject);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && sizable != null && sizable.isSelected)
        {
            sizable.Shrink(selectedObject);
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);
            GameObject oldSelection = selectedObject;
            selectedObject = GameObject.Find(hitInfo.transform.name);
            if (oldSelection != null && selectedObject != oldSelection)
            {
                sizable.isSelected = false;
            }
            if (selectedObject != null)
            {
                sizable = selectedObject.GetComponent<SizableObject>();
                sizable.isSelected = true;
                //if (sizable != null)
                //{
                //    Debug.Log("Grabbed the sizable");
                //}
                //else
                //{
                //    Debug.Log("Sizable was Null");
                //}
            }
        }
    }
}
