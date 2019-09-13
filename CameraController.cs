using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    public float rotationSpeed;

    private Vector3 cameraPos; // Current position of camera
    private Vector3 frwdDir; // Z axis of camera in world space
    private Vector3 rightDir; // X axis of camera in world space

    void Update()
    {
        cameraPos = transform.position;
        frwdDir = transform.forward;
        rightDir = transform.right;

        #region CameraMovement
        if (Input.GetKey(KeyCode.W))
        {
            cameraPos += (frwdDir * cameraSpeed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            cameraPos -= (rightDir * cameraSpeed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            cameraPos -= (frwdDir * cameraSpeed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            cameraPos += (rightDir * cameraSpeed) * Time.deltaTime;
        }
        #endregion
        #region CameraRotation

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(transform.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
        }

        #endregion

        transform.position = cameraPos;
    }
}
