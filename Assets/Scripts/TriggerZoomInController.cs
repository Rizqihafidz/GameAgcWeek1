using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomInController : MonoBehaviour
{

    public Collider ball;
    public CameraController controller;
    public float lenght;
    private void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            controller.FollowTarget(ball.transform, lenght);
        }
    }
}
