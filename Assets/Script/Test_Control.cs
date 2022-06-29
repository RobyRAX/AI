using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Control : MonoBehaviour
{
    InputMaster action;

    private void Start()
    {
        action.Player.Walk.performed += ctx => Walk(ctx.ReadValue<Vector2>());
    }

    private void Awake()
    {
        action = new InputMaster();       
    }

    private void OnEnable()
    {
        action.Enable();
    }

    void Walk(Vector2 inputCtx)
    {
        Debug.Log(inputCtx);
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
