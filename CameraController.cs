using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 10f;
    public float rotationSpeed = 50f;
    public float zoomSpeed = 200f;

    [Header("Camera Limitations")]
    public Vector2 xAxis;
    public Vector2 zAxis;
    public Vector2 zoomLimit;

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
        #region CameraZoom

        float currentZoom = Input.GetAxis("Mouse ScrollWheel");

        cameraPos.y -= currentZoom * zoomSpeed * Time.deltaTime;

        #endregion

        // Movement limitations
        cameraPos.x = Mathf.Clamp(cameraPos.x, xAxis.x, xAxis.y);
        cameraPos.z = Mathf.Clamp(cameraPos.z, zAxis.x, zAxis.y);
        // Zoom limitations
        cameraPos.y = Mathf.Clamp(cameraPos.y, zoomLimit.x, zoomLimit.y);

        transform.position = cameraPos;
    }
}
