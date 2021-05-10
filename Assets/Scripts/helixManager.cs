using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = -35;
    public float ringDistance = 5;
    public int numberofRings;
    public GameObject lastRing;

    void Start()
    {
        numberofRings = GamerManager.currentLevelIndex + 5;
        //spawn helix rings
        for (int i = 0; i < numberofRings; i++)
        {
            if (i == 0)
                SpawnRing(0);
            else
                SpawnRing(Random.Range(1, helixRings.Length -1));
        }

        //spawn the last ring
        SpawnRing(helixRings.Length - 1);
    }


    public void SpawnRing(int ringIndex)
    {
        GameObject go =Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringDistance;
    }
}
