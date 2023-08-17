using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "ScriptableObjects/PlantScriptableObject", order = 1)]
public class PlantSO : ScriptableObject
{
    public string plantName;
    public Sprite[] plantSprites;
    public int plantGrowthDuration;
}
