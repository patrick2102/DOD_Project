using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[GenerateAuthoringComponent]
public struct FollowerData : IComponentData
{
    public Translation target;
    public float acceleration;
    public float maxSpeed;
    public float slowDownRadius;
    public float stopRadius;
}
