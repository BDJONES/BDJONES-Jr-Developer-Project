using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizableObject : MonoBehaviour
{
    public bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Grow(GameObject selectedObject)
    {
        if (isSelected)
        {
            selectedObject.transform.localScale = selectedObject.transform.localScale * 2;
            Rigidbody selRb = selectedObject.GetComponent<Rigidbody>();
            selRb.mass *= 2;
        }
    }
    public void Shrink(GameObject selectedObject)
    {
        if (isSelected)
        {
            selectedObject.transform.localScale = selectedObject.transform.localScale / 2;
            Rigidbody selRb = selectedObject.GetComponent<Rigidbody>();
            selRb.mass /= 2;
        }
    }
}
