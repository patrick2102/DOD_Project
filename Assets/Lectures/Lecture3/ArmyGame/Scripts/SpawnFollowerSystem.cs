using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

partial struct SpawnFollowerJob : IJobEntity
{
    GameObject followerPrefab;
    public EntityCommandBuffer ecb;
    void Execute(in Translation translation, in GameObjectConversionSystem conversionSystem)
    {
        var e = conversionSystem.GetPrimaryEntity(followerPrefab);
        ecb.SetComponent(e, new Translation
        {
            Value = translation.Value
        });
        ecb.Instantiate(e);
    }
}

public partial class SpawnFollowerSystem : SystemBase
{
    public BeginInitializationEntityCommandBufferSystem ecbSystem;


    protected override void OnCreate()
    {
        ecbSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        var ecb = new EntityCommandBuffer(Allocator.TempJob);

        SpawnFollowerData spawnFollowerData;

        Entities.WithAny<MovementData>().ForEach((ref SpawnFollowerData sfd) =>
        {
            spawnFollowerData = sfd;
        }
        ).Run();

        int followerCount = 100;

        for (int i = 0; i < followerCount; i++)
        {
            EntityManager.Instantiate()
            Instantiate(spawnFollowerData.followerPrefab);
        }

    }

    protected override void OnUpdate()
    {
        // Update positions of followers
    }
}
