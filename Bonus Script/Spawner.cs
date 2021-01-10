using System.Collections;
using UnityEngine;


public class Spawner:MonoBehaviour
{
    public enum SpawnState {Spawning,Waiting,Counting};

    [System.Serializable]
  public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
        
    }
    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown;
    private SpawnState state = SpawnState.Counting;
    public Transform[] spawnPoints;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

   void Update()
   {
        if(state == SpawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if(state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
   }

    void WaveCompleted()
    {
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;        
    }

    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.Spawning;

        for(int i = 0; i <= wave.count; i++)
        {
            SpawnEnemy(wave.enemy[Random.Range(0,2)]);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.Waiting;
        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }

}

