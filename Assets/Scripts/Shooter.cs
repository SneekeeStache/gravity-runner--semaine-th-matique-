using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using FMODUnity;
public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Instantiate(bullet, spawnPoint.position, quaternion.identity);
        RuntimeManager.PlayOneShot("event:/ennemi_shoot");
    }
}
