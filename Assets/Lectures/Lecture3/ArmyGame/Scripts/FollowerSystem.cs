using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using Unity.Physics;
using Unity.Mathematics;
using UnityEngine;
using Unity.Jobs;
using System;

public partial class FollowerSystem : SystemBase
{
    EntityQuery queryFollow;

    protected override void OnCreate()
    {
        queryFollow = GetEntityQuery(ComponentType.ReadWrite<Translation>(), ComponentType.ReadOnly<FollowerData>());
    }

    protected override void OnUpdate()
    {
        float3 playerPos = new float3();

        Entities.WithAny<MovementData>().ForEach((ref Translation translation) =>
        {
            playerPos = translation.Value;
        }
        ).Run();

        var followerJob = new FollowerJob { dt = Time.DeltaTime, target=playerPos };

        JobHandle jbh = followerJob.Schedule();
        jbh.Complete();

        //Debug.Log("Player pos: " + playerPos);
    }

    /*
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref PhysicsVelocity pv, ref Translation t, in FollowerData fd) =>
            {
                float3 dir = t.Value - fd.target.Value;
                float dir_len = math.length(dir);
    */
                /*
                if (dir_len < fd.stopRadius)
                {
                    pv.Linear = new float3(0, 0, 0);
                    return;
                }
                /*
                else if (dir_len < fd.slowDownRadius)
                {
                    var slowDown = fd.maxSpeed * deltaTime;

                    pv.Linear -= slowDown;
                    if (slowDown > math.length(pv.Linear))
                    {
                        pv.Linear = new float3(0, 0, 0);
                    }
                }
                */

    /*
                dir /= math.length(dir);
                pv.Linear += fd.speed * deltaTime;
                if (math.length(pv.Linear) > fd.maxSpeed)
                {
                    pv.Linear /= math.length(pv.Linear);
                    pv.Linear *= fd.maxSpeed;
                }
            }
        ).Run();
    }
*/
}
