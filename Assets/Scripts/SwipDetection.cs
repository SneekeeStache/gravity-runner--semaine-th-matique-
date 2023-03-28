using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipDetection : MonoBehaviour
{
    [SerializeField] private float minimumDistance= .2f;
    [SerializeField] private float maximumTime =1f;


    private InputManager InputManager;

    private Vector2 startPosition;
    private Vector2 endPosition;
    private float startTime;
    private float endTime;


    private void Awake() {
        InputManager = InputManager.Instance;
        Debug.Log("test");
    }

    private void OnEnable() {
        InputManager.OnStartTouch += SwipeStart;
        InputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable() {
        InputManager.OnStartTouch -= SwipeStart;
        InputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time){
        startPosition = position;
        startTime= time;
    }

    private void SwipeEnd(Vector2 position, float time){
        endPosition = position;
        endTime= time;
        DetectSwipe();
    }

    private void DetectSwipe(){
        if(Vector3.Distance(startPosition,endPosition)>= minimumDistance && 
        (endTime - startTime) <= maximumTime
        ){
            Debug.DrawLine(startPosition,endPosition,Color.red,5f);
        }
    }
}
