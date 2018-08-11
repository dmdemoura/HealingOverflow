using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    private int _dificult = 0;
    [SerializeField] int startWaveSize = 2;
    [SerializeField] float waveProportionByLevel = 1.5f;
    [SerializeField] List<Transform> spawnPoints;

    //variaveis de tempo
    [SerializeField] float spawnDelay = 1;
    [SerializeField] float delayReduction = 1f;
    [SerializeField] float minimumDelay = 0.5f;
    [SerializeField] float dificultDelay = 10;
    // Use this for initialization
    void Start () {
        if (spawnPoints.Count <= 0)
        {
            spawnPoints = new List<Transform>();
            //spawn norte
            spawnPoints.Add(Instantiate(new GameObject("SpawnPointNorte")).transform);
            spawnPoints[0].position = new Vector3(0f, 7f, 0f);
            //spawn Leste
            spawnPoints.Add(Instantiate(new GameObject("SpawnPointLeste")).transform);
            spawnPoints[1].position = new Vector3(12f, 0f, 0f);
            //spawn sul
            spawnPoints.Add(Instantiate(new GameObject("SpawnPointSul")).transform);
            spawnPoints[2].position = new Vector3(0f, -7f, 0f);
            //spawn oeste
            spawnPoints.Add(Instantiate(new GameObject("SpawnPointOseste")).transform);
            spawnPoints[3].position = new Vector3(-12f, 0f, 0f);
        }
        Invoke("GetHarder", dificultDelay);
        Invoke("SpawnWave", spawnDelay);

    }

    // Update is called once per frame
    void Update () {
	}

    public void SpawnWave()
    {
        int trueSize = Mathf.CeilToInt(startWaveSize + _dificult * waveProportionByLevel);
        Vector3 spawPosition = spawnPoints[Random.Range(0, 4)].position;
        for (int i = 0; i < trueSize; i++)
        {
            Vector3 position = spawPosition + (Quaternion.AngleAxis(i * (360f / trueSize), Vector3.forward) * Vector3.right );
            GameManager.SpawnAt("Enemy", position);
        }

        Invoke("SpawnWave", minimumDelay + spawnDelay * delayReduction);
    }

    public void GetHarder()
    {
        _dificult++;
        delayReduction *= 0.9f;
        Invoke("GetHarder", dificultDelay);
    }
}
