using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;
    float yaw;
    float pitch;
    private float xAxisClamp = 0.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        LockCursor();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        yaw = mouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch = mouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

        xAxisClamp += pitch;

        if(xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            pitch = 0.0f;
            ClampXaxisToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            pitch = 0.0f;
            ClampXaxisToValue(90.0f);
        }
        transform.Rotate(Vector3.left * pitch);
        playerBody.Rotate(Vector3.up * yaw);
    }

    private void ClampXaxisToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }












    void Start()
    {
        
    }

    // Update is called once per frame

}
