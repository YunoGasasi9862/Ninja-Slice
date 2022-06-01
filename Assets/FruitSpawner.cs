using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitprefab;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;
    void Start()
    {
        
    }

    IEnumerator SpawnFruits()
    {

        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);  //it waits or delays the next execution of the line :))


            int spawnIndex = Random.Range(0, spawnPoints.Length); //between 0 to the max sizeo f the array

            Instantiate(fruitprefab);



        }

    }
}
