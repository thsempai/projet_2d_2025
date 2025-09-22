using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class MoveHero : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float speed;
    InputAction xAxis;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        xAxis = actions.FindActionMap("Luigi").FindAction("XAxis");
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
        transform.Translate(xAxis.ReadValue<float>() * speed * Time.deltaTime, 0f, 0f);
    }
}
