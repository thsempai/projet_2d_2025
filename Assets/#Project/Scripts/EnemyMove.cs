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

        Vector3 origin = transform.position + 0.4f * Vector3.up + Vector3.right * 0.4f * (goRight ? 1f : -1f);
        Vector3 direction = Vector3.right * (goRight ? 1f : -1f);

        Debug.DrawRay(origin, direction * 0.02f, Color.cyan);
        RaycastHit2D sideHit = Physics2D.Raycast(origin, direction, 0.02f);

        origin = transform.position + Vector3.right * 0.4f * (goRight ? 1f : -1f);
        direction = Vector3.down;

        Debug.DrawRay(origin, direction * 1.01f, Color.yellow);
        RaycastHit2D bellowHit = Physics2D.Raycast(origin, direction, 1.01f);

        if (sideHit.collider != null || bellowHit.collider == null)
        {
            InverseSpeed();
        }
    }


    private void InverseSpeed()
    {
        goRight = !goRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
