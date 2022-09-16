using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using Unity.Physics;
using Unity.Mathematics;
using UnityEngine;

public partial class FollowerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref PhysicsVelocity pv, ref Translation t, in FollowerData fd) =>
            {
                float3 dir = t.Value - fd.target.Value;
                float dir_len = math.length(dir);

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
}
