using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer laserRenderer;

    public bool laserAnimBool=false;
    [SerializeField] private float speed;

    [SerializeField] private Vector3 LaserFinalPosition;

    [SerializeField] private Transform endLaser;

    private Vector3 linecastPosition;
    // Start is called before the first frame update
    void Start()
    {
        laserOff();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(linecastPosition);

        if (laserAnimBool)
        {
            linecastPosition = Vector3.Lerp(linecastPosition, endLaser.position, Time.deltaTime * speed);
            laserRenderer.SetPosition(1,
                Vector3.Lerp(laserRenderer.GetPosition(1), LaserFinalPosition, Time.deltaTime * speed));
            RaycastHit2D hit = (Physics2D.Linecast(transform.position, linecastPosition));
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    hit.collider.GetComponent<playerScript>().death();
                }
            }
            
            Debug.DrawLine(transform.position, linecastPosition, Color.green);
        }
    }

    public void laserOn()
    {
        laserAnimBool = true;
    }

    public void laserOff()
    {
        linecastPosition = transform.position;
        laserAnimBool = false;
        laserRenderer.SetPosition(1,new Vector3(0,0,0));
    }
}
