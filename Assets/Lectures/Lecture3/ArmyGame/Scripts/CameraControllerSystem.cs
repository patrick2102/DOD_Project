using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class CameraControllerSystem : SystemBase
{
    protected override void OnUpdate()
    {

        var deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in CameraControllerData ccd) =>
            {
                if (Input.GetKey(ccd.forward))
                {
                    translation.Value.z += ccd.cameraSpeed * deltaTime;
                }
                if (Input.GetKey(ccd.backward))
                {
                    translation.Value.z -= ccd.cameraSpeed * deltaTime;
                }
                if (Input.GetKey(ccd.left))
                {
                    translation.Value.x += ccd.cameraSpeed * deltaTime;
                }
                if (Input.GetKey(ccd.right))
                {
                    translation.Value.x -= ccd.cameraSpeed * deltaTime;
                }
                if (Input.GetKey(ccd.up))
                {
                    translation.Value.y += ccd.cameraSpeed * deltaTime;
                    if (translation.Value.y > ccd.maxHeight)
                        translation.Value.y = ccd.maxHeight;
                }
                if (Input.GetKey(ccd.down))
                {
                    translation.Value.y -= ccd.cameraSpeed * deltaTime;
                    if (translation.Value.y < ccd.minHeight)
                        translation.Value.y = ccd.minHeight;
                }
            }

        ).Run();
    }
}
