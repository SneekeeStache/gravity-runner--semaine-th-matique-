using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> paternsFacile = new List<GameObject>();
    [SerializeField] private List<GameObject> paternsMoyen = new List<GameObject>();
    [SerializeField] private List<GameObject> paternsDifficile = new List<GameObject>();

    [Header("parametre")] 
    [SerializeField] private float distanceDificultyUp;
    //choix paterns determine quel list de paterns le spawner va utiliser
    private int choixPaterns1 = 1;
    private int choixPaterns2 = 2;
    private int choixPaterns3 = 3;
    private float timerScore = 0;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
