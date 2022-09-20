using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Physics;
using Unity.Mathematics;
using Unity.Physics.Extensions;

public partial class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.ForEach((ref PhysicsVelocity pv, ref Translation translation, in MovementData movementData, in PhysicsMass pm) =>
        {
            var dir = new float3(0);

            if (Input.GetKey("w"))
            {
                dir.z += 1;
            }
            if (Input.GetKey("a"))
            {
                dir.x -= 1;

            }
            if (Input.GetKey("s"))
            {
                dir.z -= 1;

            }
            if (Input.GetKey("d"))
            {
                dir.x += 1;
            }
            if (math.length(dir) == 0)
                return;

            dir /= math.length(dir);
            dir *= movementData.speed * deltaTime;
            //Debug.Log(dir);

            if (math.length(dir) > movementData.maxSpeed)
            {
                dir /= math.length(dir);
                dir *= movementData.maxSpeed;
            }
            pv.ApplyLinearImpulse(pm, dir);

        }).Run();
    }
}
