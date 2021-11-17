using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomSeed : MonoBehaviour
{
    public string stringSeed = "seed string";
    public bool useStringSeed;
    public int seed;
    public bool randomizeSeed;

    
    void Awake()
    {
        if (useStringSeed)
        {
            //Turns the string into a seed by using character hashcodes
            seed = stringSeed.GetHashCode();
        }

        if (randomizeSeed)
        {
            //If the option is selected, gets a random number from 0 to 99999 and sets it as the seed
            seed = Random.Range(0, 99999);
        }

        //Hover InitState
        Random.InitState(seed);
    }
    
}
