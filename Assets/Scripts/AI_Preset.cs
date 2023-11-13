using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "preset")]
public class AI_Preset : ScriptableObject
{
    public bool firstCycle = true;
    public float wighths;
    public int bestObs;
    public int cycle;
}
