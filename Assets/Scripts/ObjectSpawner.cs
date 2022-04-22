using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject gatePrefab;
    private GameObject gate;
    public List<GameObject> keys = new List<GameObject>();
    public GameObject key;

    [SerializeField]
    private MapGenerator mapGenerator;

    //Spawn gate with GetRandomLocation
    public void SpawnGate()
    {
        Vector3 gateLocation = mapGenerator.GetRandomLocation();
        gateLocation = new Vector3(gateLocation.x, gateLocation.y - 3.85f, gateLocation.z);
        GameObject newGate = Instantiate(gatePrefab, gateLocation, Quaternion.identity);
        gate = newGate;
    }

    //Spawn 1-5 keys on the map, making sure they're not inside a wall tile
    public void SpawnKeys()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnKey();
        }
    }

    //Spawn Key using GetRandomLocation
    public void SpawnKey()
    {
        Vector3 location = mapGenerator.GetRandomLocation();
        GameObject keyObject = Instantiate(
            key,
            new Vector3(location.x, -3.5f, location.y),
            Quaternion.identity
        );
        keyObject.transform.parent = transform;
        keys.Add(keyObject);
    }

    //Clear all keys from the map
    public void ClearKeys()
    {
        foreach (GameObject key in keys)
        {
            Destroy(key);
        }
        keys.Clear();
    }

    //Clear the gate from the map
    public void ClearGate()
    {
        Destroy(gate);
    }
}
