using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public ObjectSpawner objectSpawner;

    void Awake()
    {
        mapGenerator = FindObjectOfType<MapGenerator>();
        objectSpawner = FindObjectOfType<ObjectSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NextLevelInit();
        }
    }

    void NextLevelInit()
    {
        //Clears and re-generates map
        mapGenerator.ClearMap();
        mapGenerator.GenerateMap();
        
        //Clears keys and gate and re-generates them
        objectSpawner.ClearGate();
        objectSpawner.ClearKeys();
        objectSpawner.SpawnGate();
        objectSpawner.SpawnKeys();
    }
}
