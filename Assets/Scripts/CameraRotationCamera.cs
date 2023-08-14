using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationCamera : MonoBehaviour
{
    private float horizontalCameraInput;
    private float verticalCameraInput;
    public float sensitivity = -1f;
    private Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalCameraInput = Input.GetAxis("Mouse X");
        verticalCameraInput = Input.GetAxis("Mouse Y");
        rotate = new Vector3(verticalCameraInput * sensitivity, horizontalCameraInput , 0);
        transform.eulerAngles = transform.eulerAngles + rotate;
    }
}
