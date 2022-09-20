using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Extensions;
using Unity.Transforms;
using UnityEngine;

partial struct FollowerJob : IJobEntity
{
    public float dt;
    public float3 target;
    void Execute(ref PhysicsVelocity pv, ref Translation t, ref FollowerData fd, in PhysicsMass pm)
    {
        //Update followVector
        //fd.target = sfd.pla

        //Follow vector:
        var followVector = target - t.Value;
        followVector.y = 0;
        float dir_len = math.length(followVector);
        followVector /= dir_len;

        if (dir_len < fd.slowDownRadius)
            return;

        followVector *= fd.acceleration * dt;
        if (math.length(followVector) > fd.maxSpeed)
        {
            followVector /= math.length(followVector);
            followVector *= fd.maxSpeed;
        }

        //Avoid vector not implemented

        //Debug.Log("this: " + t.Value);
        //Debug.Log("target: " + target);
        //Debug.Log("follow: " + followVector);

        //Apply movement:

        pv.ApplyLinearImpulse(pm, followVector);

        //pv.Add(pm, t, rot, )
        //pv.Linear = followVector;
    }

}
