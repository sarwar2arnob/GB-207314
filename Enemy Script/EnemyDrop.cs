using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField]
    GameObject DNAPoint;
    [SerializeField]
    GameObject RedBloodCell;
    [SerializeField]
    float SpawnYPos;
    [SerializeField]
    int DNADropAmount, RedBloodCellAmount;
    // Start is called before the first frame update
    public void Drop()
    {
        for (int i = 0; i < DNADropAmount; i++)
        {
            Instantiate(DNAPoint, new Vector2(transform.position.x+Random.Range(-1f,.5f), transform.position.y + SpawnYPos+ Random.Range(.5f, .8f)), transform.rotation);
        }
        for(int i = 0; i < RedBloodCellAmount; i++)
        {
            _ = Instantiate(RedBloodCell, new Vector2(transform.position.x + Random.Range(-1f, .5f), transform.position.y + SpawnYPos + Random.Range(.5f, .8f)), transform.rotation);
        }
    }
}
