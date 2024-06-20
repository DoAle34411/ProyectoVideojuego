using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighestLevel : MonoBehaviour
{
    public static int highestLevel = 1; 

    public static void SaveHighestLevel(int level)
    {
        if (level > highestLevel)
        {
            highestLevel = level;
        }
    }

    public static int GetHighestLevel()
    {
        return highestLevel;
    }
}
