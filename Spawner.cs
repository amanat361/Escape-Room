using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject floor;
    public GameObject wall;
    private int mazeSize;
    private Vector3 wallSize, floorSize;
    private Vector3 spawnPos;
    private int rotation, modifier;
    float x, y, z, dx, dz;
    List<int[]> maze;

    void Start()
    {
        InitializeMaze();
    }

    void UpdateCoordinates()
    {
        x = maze[rotation % maze.Count][1] * wallSize.x;
        z = maze[rotation % maze.Count][0] * wallSize.x;
        dx = maze[rotation % maze.Count][1] * wallSize.z / 2;
        dz = maze[rotation % maze.Count][0] * wallSize.z / 2;
    }

    void InitializeMaze()
    {
        // get wall size and maze size
        wallSize = wall.transform.localScale;
        floorSize = floor.transform.localScale;
        mazeSize = (int)floorSize.x / (int)wallSize.x;

        // set maze directions
        maze = new List<int[]>() { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

        // set initial rotation to 0
        rotation = 0;
        modifier = 0;

        // set initial spawn position
        x = (floorSize.x / -2f) + (wallSize.x / 2f);
        z = (floorSize.z / -2f) + (wallSize.z / 2f);
        y = (floorSize.y /  2f) + (wallSize.y / 2f);
        spawnPos = new Vector3(x, y, z);

        // update x, z, dx, dz
        UpdateCoordinates();

        // spawn walls
        for (int i = 1; rotation < mazeSize; i++)
        {
            // instantiate wall
            GameObject newWall = Instantiate(wall, spawnPos, Quaternion.identity, transform);
            newWall.transform.Rotate(0, rotation * 90, 0);

            // if we've reached the end of a row, update spawn position
            if ((i+modifier) % mazeSize == 0)
            {
                spawnPos += new Vector3(x/2 - dx, 0, z/2 - dz);
                rotation++;
                modifier += rotation;
                UpdateCoordinates();
                spawnPos += new Vector3(x/2 - dx, 0, z/2 - dz);
            } else {
                spawnPos += new Vector3(x, 0, z);
            }
        }
    }
}
