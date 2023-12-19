using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider ball;

    [SerializeField] private float multiplier;
    [SerializeField] private Color color; 
    [SerializeField] private float score;
    private Rigidbody ballRb;
    private Renderer render;
    private Animator animator;

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private VFXManager vfxManager;
    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        render = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        render.material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == ball)
        {
            ballRb = ball.GetComponent<Rigidbody>();
            ballRb.velocity *= multiplier;
        }

        animator.SetTrigger("hit");

        audioManager.PlaySFX(collision.transform.position);

        vfxManager.PlayVFX(collision.transform.position);

        scoreManager.AddScore(score);
    }
}
