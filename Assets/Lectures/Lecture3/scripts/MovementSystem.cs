using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public partial class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.ForEach((ref Translation translation, in MovementData movementData) =>
        {
            if (Input.GetKey("w"))
            {
                translation.Value.y += movementData.speed;
            }
            if (Input.GetKey("a"))
            {
                translation.Value.x -= movementData.speed;

            }
            if (Input.GetKey("s"))
            {
                translation.Value.y -= movementData.speed;

            }
            if (Input.GetKey("d"))
            {
                translation.Value.x += movementData.speed;
            }

        }).Run();
    }
}
