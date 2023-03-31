using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> paternsFacile = new List<GameObject>();
    [SerializeField] private List<GameObject> paternsMoyen = new List<GameObject>();
    [SerializeField] private List<GameObject> paternsDifficile = new List<GameObject>();
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject canvasScore;
    [SerializeField] private FMODUnity.StudioEventEmitter music;
    
    [Header("parametre")] 
    [SerializeField] private float timeSpawn=0.5f;
    public float paternSpeed=3;

    private float timerSpawn = 0;
    //choix paterns determine quel list de paterns le spawner va utiliser
    private const int choixPaterns1 = 1;
    private const int choixPaterns2 = 2;
    private const int choixPaterns3 = 3;
    private int choixPaterns = 1;
    private float timerScore = 0;
    [SerializeField]private float niveau1a2 = 20;
    [SerializeField]private float niveau2a3 = 60;
    [HideInInspector]public bool StartSpawning = false;

    [HideInInspector] public bool startGame = false;
    // Start is called before the first frame update
    void Start()
    {
    canvasScore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            music.SetParameter("start",1);
            timerScore += Time.deltaTime;
            int currentScore = Mathf.RoundToInt(timerScore);
            score.text = currentScore.ToString();
            if (StartSpawning)
            {
                if (timerSpawn < timeSpawn)
                {
                    timerSpawn += Time.deltaTime;
                }
                else if (timerSpawn >= timeSpawn)
                {
                    int choixNiveau =Random.Range(0, 100);
                    if (choixPaterns == choixPaterns1)
                    {
                        int choixUnPaterne = Random.Range(0, paternsFacile.Count);
                        Instantiate(paternsFacile[choixUnPaterne], new Vector3(0, 6, 0), Quaternion.Euler(0, 0, 0));
                    }else if (choixPaterns == choixPaterns2)
                    {
                        if (choixNiveau <= 30)
                        {
                            int choixUnPaterne = Random.Range(0, paternsFacile.Count);
                            Instantiate(paternsFacile[choixUnPaterne], new Vector3(0, 6, 0), Quaternion.Euler(0, 0, 0));
                        }else if (choixNiveau > 30)
                        {
                            int choixUnPaterne = Random.Range(0, paternsMoyen.Count);
                            Instantiate(paternsMoyen[choixUnPaterne], new Vector3(0, 6, 0), Quaternion.Euler(0, 0, 0));
                        }
                    }else if (choixPaterns == choixPaterns3)
                    {
                        if (choixNiveau <= 25)
                        {
                            int choixUnPaterne = Random.Range(0, paternsFacile.Count);
                            Instantiate(paternsFacile[choixUnPaterne], new Vector3(0, 6, 0), Quaternion.Euler(0, 0, 0));
                        }else if (choixNiveau > 25 && choixNiveau <= 50)
                        {
                            int choixUnPaterne = Random.Range(0, paternsMoyen.Count);
                            Instantiate(paternsMoyen[choixUnPaterne], new Vector3(0, 6, 0), Quaternion.Euler(0, 0, 0));
                        }else if (choixNiveau > 50)
                        {
                            int choixUnPaterne = Random.Range(0, paternsDifficile.Count);
                            Instantiate(paternsDifficile[choixUnPaterne], new Vector3(0, 6, 0), Quaternion.Euler(0, 0, 0));
                        }
            
                    }
                    timerSpawn = 0;
                    StartSpawning = false;
                }
            }
        }
        
        if (timerScore >= niveau1a2)
        {
            choixPaterns = choixPaterns2;
            paternSpeed = 5;
        }
        else if (timerScore >= niveau2a3)
        {
            choixPaterns = choixPaterns3;
            paternSpeed=7;
        }

    }
}
