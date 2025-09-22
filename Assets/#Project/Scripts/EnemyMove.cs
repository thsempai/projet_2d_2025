using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] bool goRight = true;

    SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(speed * (goRight ? 1f : -1f) * Time.deltaTime, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle")){
            InverseSpeed();
        }
    }

    private void InverseSpeed()
    {
        goRight = !goRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
