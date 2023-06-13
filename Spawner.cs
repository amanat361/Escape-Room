using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wall;
    private Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWall", 0, 1);
    }

    void SpawnWall() {
        spawnPos.x = Random.Range(-50, 50);
        spawnPos.y = 1.5f;
        spawnPos.z = Random.Range(-50, 50);
        Instantiate(wall, spawnPos, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
