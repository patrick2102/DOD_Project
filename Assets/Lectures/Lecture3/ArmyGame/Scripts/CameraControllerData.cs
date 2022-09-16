using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct CameraControllerData : IComponentData
{
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;

    public KeyCode up;
    public KeyCode down;

    public float cameraSpeed;

    public float maxHeight;
    public float minHeight;
}
