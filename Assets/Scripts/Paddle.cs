using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private string input;

    private float targetPressed;
    private float targetReleased;
    private HingeJoint joint;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();

        targetPressed = joint.limits.max;
        targetReleased = joint.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = joint.spring;

        if (Input.GetButton(input))
        {
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetReleased;
        }
        joint.spring = jointSpring;
    }
}
