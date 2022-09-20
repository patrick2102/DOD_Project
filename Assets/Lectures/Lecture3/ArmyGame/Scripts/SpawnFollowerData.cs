using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[GenerateAuthoringComponent]
public struct SpawnFollowerData : IComponentData
{
    public Translation player;

    public int followerCount;
    public Translation spawnPoint;
    public float spawnRadius;

    public GameObject followerPrefab;

    //public List<Translation> followerPositions;
}
