using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{

    [SerializeField] static float vitesseScrolling=9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+= -transform.up*vitesseScrolling*Time.deltaTime;
        if(transform.position.y <= -9.60){
            transform.position=new Vector3(transform.position.x,15.99f,transform.position.z);
        }
    }
}
