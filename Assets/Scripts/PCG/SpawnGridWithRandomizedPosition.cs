using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGridWithRandomizedPosition : MonoBehaviour
{

    public GameObject[] itemsToPickFrom;
    public int gridX;
    public int gridZ;
    public float gridSpacingOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;
    public Vector3 positionRandomization;

    void Start()
    {
        SpawnGrid();
    }

    void SpawnGrid()
    {
        //Loops through the x and z axis of the grid to place random objects
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + gridOrigin;
                PickAndSpawn(RandomizedPosition(spawnPosition), Quaternion.identity);
            }
        }
    }

    Vector3 RandomizedPosition(Vector3 position)
    {
        //returns a random vector3 based on the variable
        Vector3 randomizedPosition = new Vector3(Random.Range(-positionRandomization.x, positionRandomization.x), Random.Range(-positionRandomization.y, positionRandomization.y), Random.Range(-positionRandomization.z, positionRandomization.z)) + position;
        return randomizedPosition;
    }

    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        //Instantiates a clone of a random prefab from a list at set coordinates
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }
}
