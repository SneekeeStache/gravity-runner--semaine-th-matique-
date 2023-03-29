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
    [Range(0,1)]
    [SerializeField] private float directionThreshold = .9f;

    [SerializeField] private GameObject trail;

    [SerializeField] private playerScript Player;

    private Coroutine coroutineTrail;

    private void Awake() {
        InputManager = InputManager.Instance;
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
        trail.SetActive(true);
        trail.transform.position=position;
        coroutineTrail = StartCoroutine(Trail());
    }

        private IEnumerator Trail(){
            while(true){
                trail.transform.position=InputManager.primaryPosition();
                yield return null;
            }
        }

    private void SwipeEnd(Vector2 position, float time){
        endPosition = position;
        endTime= time;
        DetectSwipe();
        trail.SetActive(false);
        StopCoroutine(coroutineTrail);

    }

    private void DetectSwipe(){
        if(Vector3.Distance(startPosition,endPosition)>= minimumDistance && 
        (endTime - startTime) <= maximumTime
        ){
            Debug.DrawLine(startPosition,endPosition,Color.red,5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D= new Vector2(direction.x,direction.y).normalized;
            SwipDirection(direction2D);
        }
    }

    private void SwipDirection(Vector2 direction){
        if(Vector2.Dot(Vector2.up,direction)> directionThreshold){
            Debug.Log("swip up");
        }
        else if(Vector2.Dot(Vector2.down,direction)> directionThreshold){
            Debug.Log("swip down");
        }
        else if(Vector2.Dot(Vector2.left,direction)> directionThreshold){
            if(!Player.onLeft && Player.onGround){
                Player.GoLeftSide();
                Player.onLeft=true;
            }
            Debug.Log("swip left");
        }
        else if(Vector2.Dot(Vector2.right,direction)> directionThreshold){
            if(Player.onLeft && Player.onGround){
                Player.GoRightSide();
                Player.onLeft=false;
            }
            Debug.Log("swip Right");
        }
    }
}
