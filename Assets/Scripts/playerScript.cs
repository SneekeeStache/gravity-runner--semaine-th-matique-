using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
public class playerScript : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;

    public bool onLeft = true;

    [Header("Stats")]
    [SerializeField] float jumpForce = 2;
    [SerializeField] float rotationDuration = 0.5f;
    [HideInInspector] public bool onGround=false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoLeftSide()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        rb.gravityScale = 1;
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, -90), rotationDuration);

    }

    public void GoRightSide()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, -270), rotationDuration);
        rb.gravityScale = -1; 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        onGround=true;
    }
    private void OnCollisionExit2D(Collision2D other) {
        onGround=false;
    }
}
