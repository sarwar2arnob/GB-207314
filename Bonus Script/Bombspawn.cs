using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bombspawn : MonoBehaviour
{

    public Transform[] spawnpoints;
    public GameObject[] enemyPrefabs;
    public float timer;
    public int[] gos;
    public int x;

    void Start()
    {
        StartCoroutine(wave());
    }

    private void Update()
    {
        
    }
    private void spawn()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnpoint = Random.Range(0, spawnpoints.Length);
        gos = new int [x];
        for (int i = 0; i < gos.Length; i++)
        {
            Instantiate(enemyPrefabs[randEnemy], spawnpoints[randSpawnpoint].position, transform.rotation);
        }
        x += 1;
    }

    IEnumerator wave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            spawn();

        }
    }
}
