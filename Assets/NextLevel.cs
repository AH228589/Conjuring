using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject mapGenerator;
    
    void Awake()
    {
        mapGenerator = GameObject.Find("Map Generator");
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
        mapGenerator.GetComponent<MapGenerator>().ClearMap();
        mapGenerator.GetComponent<MapGenerator>().GenerateMap();
        mapGenerator.GetComponent<MapGenerator>().SpawnKeys();
    }
}
