using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct MovementData : IComponentData
{
    public float speed;
    public float maxSpeed;
}
