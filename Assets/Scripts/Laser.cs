using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer laserRenderer;

    public bool laserAnimBool=false;
    [SerializeField] private float speed;

    [SerializeField] private Vector3 LaserFinalPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(laserRenderer.GetPosition(1));
        if (laserAnimBool)
        {
            laserRenderer.SetPosition(1,Vector3.Lerp(laserRenderer.GetPosition(1),LaserFinalPosition,Time.deltaTime*speed));
        }
    }

    public void laserOn()
    {
        laserAnimBool = true;
    }

    public void laserOff()
    {
        laserAnimBool = false;
        laserRenderer.SetPosition(1,new Vector3(0,0,0));
    }
}
