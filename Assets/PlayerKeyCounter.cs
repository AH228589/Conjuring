using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyCounter : MonoBehaviour
{
    public List<GameObject> keys = new List<GameObject>();

    public int GetKeyCount()
    {
        return keys.Count;
    }

}
