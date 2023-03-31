using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.SceneManagement;
using FMODUnity;

public class playerScript : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;

    public bool onLeft = true;

    private InputManager InputManager;

    [Header("Stats")]
    FMOD.Studio.Bus MasterBus;
    [SerializeField] float jumpForce = 2;
    [SerializeField] float rotationDuration = 0.5f;
    [HideInInspector] public bool onGround=false;
    [SerializeField] private Animator AnimManager;
    [SerializeField] private GameObject Swip;

    [SerializeField] public Canvas gameOver;
    [SerializeField] public Canvas UI;
    [SerializeField] private Animator menuAnim;

    [SerializeField] private InputActionReference touch;

    public bool gameoverBool = false;



    void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameoverBool)
        {
                if(touch.action.phase == InputActionPhase.Performed)
                {
                    Swip.SetActive(false);
                    SceneManager.LoadScene("Scenes/SampleScene 1");
                    MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

                }
        }
    }


    public void GoLeftSide()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        rb.gravityScale = 1;
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, -90), rotationDuration);
        transform.DOScaleX(-1.25f, rotationDuration);
        RuntimeManager.PlayOneShot("event:/jump");

    }

    public void GoRightSide()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, -270), rotationDuration);
        transform.DOScaleX(1.25f,rotationDuration);
        rb.gravityScale = -1;
        menuAnim.SetBool("StartGame", true);
        UI.gameObject.SetActive(true);
        RuntimeManager.PlayOneShot("event:/jump");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        onGround=true;
        AnimManager.SetBool("Jumping", false);
    }
    private void OnCollisionExit2D(Collision2D other) {
        onGround=false;
        AnimManager.SetBool("Jumping", true);
    }

    public void death()
    {
        AnimManager.SetBool("Dead",true);
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        gameoverBool = true;
        RuntimeManager.PlayOneShot("event:/death");
        
        
    }
}
