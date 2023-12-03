using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider ball;

    [SerializeField] private KeyCode input;

    [SerializeField] private float maxForce;
    [SerializeField] private float maxTimeHold;

    private bool isHold = false;

    private void OnCollisionStay(Collision collision)
    {
        ReadInput(ball);
    }

    private void ReadInput(Collider col)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(col));
        }
    }

    private IEnumerator StartHold(Collider col)
    {
        isHold = true;

        float force = 0f;
        float timeHold = 0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        col.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false; 
    }
}
