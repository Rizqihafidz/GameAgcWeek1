using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        off, 
        on, 
        blink
    }

    public Collider ball;
    public Material offMaterial;
    public Material onMaterial;

    private SwitchState state;
    private Renderer render;

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private VFXManager vfxManager;

    private void Start()
    {
        render = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == ball)
        {
            Toggle();
        }

        audioManager.PlaySFX(other.transform.position);

        vfxManager.PlayVFX(other.transform.position);
    }

    private void Set(bool active)
    {
        if(active == true)
        {
            state = SwitchState.on;
            render.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.off;
            render.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.on)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.blink;

        for (int i = 0; i < times; i++)
        {
            render.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            render.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
        state = SwitchState.off;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
