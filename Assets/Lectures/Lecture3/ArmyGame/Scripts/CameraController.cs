using System.Collections;
using System.Collections.Generic;
using Unity.Transforms;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public KeyCode up = KeyCode.Q;
    public KeyCode down = KeyCode.Z;

    public float cameraSpeed;

    public float maxHeight;
    public float minHeight;

    void FixedUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        var deltaTime = Time.deltaTime;

        if (Input.GetKey(forward))
        {
            cameraTransform.Translate(new Vector3(0, 0, cameraSpeed * deltaTime), Space.World);
        }
        if (Input.GetKey(backward))
        {
            cameraTransform.Translate(new Vector3(0, 0, cameraSpeed * deltaTime * -1), Space.World);
        }
        if (Input.GetKey(left))
        {
            cameraTransform.Translate(new Vector3(cameraSpeed * deltaTime * -1, 0, 0), Space.World);
        }
        if (Input.GetKey(right))
        {
            cameraTransform.Translate(new Vector3(cameraSpeed * deltaTime, 0, 0), Space.World);
        }
        if (Input.GetKey(up))
        {
            cameraTransform.Translate(new Vector3(0, cameraSpeed * deltaTime, 0), Space.World);
            if (cameraTransform.position.y > maxHeight)
                cameraTransform.position = new Vector3(cameraTransform.position.x, maxHeight, cameraTransform.position.z);
        }
        if (Input.GetKey(down))
        {
            cameraTransform.Translate(new Vector3(0, cameraSpeed * deltaTime * -1, 0), Space.World);
            if (cameraTransform.position.y < minHeight)
                cameraTransform.position = new Vector3(cameraTransform.position.x, maxHeight, cameraTransform.position.z);
        }
    }

}
