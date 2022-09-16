using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class EnemySpawnerSystem : SystemBase
{

    public GameObject enemyPrefab;
    public Entity enemyEntity;

    public void override OnCreat

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

        dstManager.AddComponentData(entity, new EntityPrefabHolder
        {
            Value = conversionSystem.GetPrimaryEntity(enemyPrefab)
        });
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(enemyPrefab);
    }

    protected override void OnUpdate()
    {

        float deltaTime = Time.DeltaTime;
        Entities.ForEach((in EnemySpawnerData enemySpawnerData, in Translation trans) =>
        {
            Entity enemy = EntityManager.Instantiate(enemyEntity);

            var spawnPoint = new Translation { Value = (enemySpawnerData.leftTopBorder - enemySpawnerData.rightTopBorder) * Random.Range(0.0f, 1.0f) + enemySpawnerData.leftTopBorder };

            EntityManager.SetComponentData(enemy, spawnPoint);

        }).WithStructuralChanges().Run();

    }

    public struct EntityPrefabHolder : IComponentData
    {
        public Entity Value;
    }

}
