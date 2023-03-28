using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [Header("Inputs")]
    [SerializeField] private InputActionReference jumpInput;
    // Start is called before the first frame update

    private void OnEnable() {
        jumpInput.action.performed += ctx => jump(ctx);
        jumpInput.action.canceled += ctx => jump(ctx);
        jumpInput.action.started += ctx => jump(ctx);
    }

    private void OnDisable() {
        jumpInput.action.performed -= ctx => jump(ctx);
        jumpInput.action.canceled -= ctx => jump(ctx);
        jumpInput.action.started -= ctx => jump(ctx);
    }
    [Header("stats")]
    [SerializeField] float jumpForce;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(jumpInput.action.phase);
    }

    void jump(InputAction.CallbackContext ctx)
    {
        print(ctx.phase);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
