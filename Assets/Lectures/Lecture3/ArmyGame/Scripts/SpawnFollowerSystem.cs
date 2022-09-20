using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class SpawnFollowerSystem : SystemBase
{


    protected override void OnCreate()
    {

        // Spawn followers:
        /*
        Pseudocode:
        for(i = 0;  i < followers_n; i++)
        {
            var follower = new Follower();
            followerSpawnerData.add(follower.Translation);
        }

         */
        // 
        //
        //

        base.OnCreate();
    }

    protected override void OnUpdate()
    {
        // Update positions of followers
    }
}
