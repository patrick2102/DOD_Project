using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[GenerateAuthoringComponent]
public struct EnemySpawnerData : IComponentData
{
    public float3 leftTopBorder;
    public float3 rightTopBorder;
    public float spawnTime;
}
