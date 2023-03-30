using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    [SerializeField] private float speed=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
        if (transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
