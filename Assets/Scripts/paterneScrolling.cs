using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paterneScrolling : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPosition= new Vector3(0,6,0);

    [SerializeField] private Vector3 destroyPosition;

    [SerializeField] private float speed=2;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= destroyPosition.y)
        {
            Destroy(gameObject);
        }

        transform.position += -transform.up * speed * Time.deltaTime;
    }
}
