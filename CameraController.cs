using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;

    protected Vector3 cameraPos;

    void Update()
    {
        cameraPos = transform.position;
        Debug.Log(cameraSpeed);
        if (Input.GetKey(KeyCode.W))
        {
            cameraPos.x += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {

        }

        if (Input.GetKey(KeyCode.S))
        {

        }

        if (Input.GetKey(KeyCode.D))
        {

        }

        transform.position = cameraPos;
    }
}
