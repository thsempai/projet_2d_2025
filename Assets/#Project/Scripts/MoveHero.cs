using System;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class MoveHero : MonoBehaviour
{

    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float speed;
    private InputAction xAxis;

    private SpriteRenderer renderer;
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        xAxis = actions.FindActionMap("Luigi").FindAction("XAxis");
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        actions.FindActionMap("Luigi").Enable();
    }

    private void OnDisable()
    {
        actions.FindActionMap("Luigi").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MoveX();
    }

    private void MoveX()
    {

        renderer.flipX = xAxis.ReadValue<float>() < 0;
        animator.SetFloat("speed", Mathf.Abs(xAxis.ReadValue<float>()));
        transform.Translate(xAxis.ReadValue<float>() * speed * Time.deltaTime, 0f, 0f);
    }
}
