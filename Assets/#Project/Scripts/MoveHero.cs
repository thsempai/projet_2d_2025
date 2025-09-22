using System;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class MoveHero : MonoBehaviour
{

    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 300f;
    private InputAction xAxis;

    private SpriteRenderer renderer;
    private Animator animator;

    private Rigidbody2D rb;
    private bool isJumping = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        xAxis = actions.FindActionMap("Luigi").FindAction("XAxis");
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        actions.FindActionMap("Luigi").Enable();
        actions.FindActionMap("Luigi").FindAction("Jump").performed += OnJump;
    }

    private void OnDisable()
    {
        actions.FindActionMap("Luigi").Disable();
        actions.FindActionMap("Luigi").FindAction("Jump").performed -= OnJump;
    }

    // Update is called once per frame
    void Update()
    {
        MoveX();

        if(isJumping){
            {
                
            }
            if(rb.linearVelocityY < 0f) {
                isJumping = false;
                animator.SetBool("on jump", false);
            }
        }
    }

    private void MoveX()
    {

        renderer.flipX = xAxis.ReadValue<float>() < 0;
        animator.SetFloat("speed", Mathf.Abs(xAxis.ReadValue<float>()));
        transform.Translate(xAxis.ReadValue<float>() * speed * Time.deltaTime, 0f, 0f);
    }

    private void OnJump(InputAction .CallbackContext context){
        rb.AddForce(Vector3.up * jumpForce);
        animator.SetBool("on jump", true);
        isJumping = true;
    }
}
