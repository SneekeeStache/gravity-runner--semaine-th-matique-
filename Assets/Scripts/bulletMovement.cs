using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    private GameObject spawner;

    private Spawner spawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        spawner=GameObject.Find("Spawner");
        spawnerScript = spawner.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += -transform.up * (spawnerScript.paternSpeed+2f) * Time.deltaTime;
        if (transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
