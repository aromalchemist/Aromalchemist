using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantTile
{
    public PlantSO plantSO;
    public Tile tile;

    public int spriteIndex = 0;
    public float growthDuration;
    public bool harvestable;

    public PlantTile(PlantSO _plantSO, Tile _tile)
    {
        plantSO = _plantSO;
        tile = _tile;
        tile.sprite = plantSO.plantSprites[spriteIndex];
        
        RandomizeGrowthDuration();
    }

    public void RandomizeGrowthDuration()
    {
        growthDuration = Random.Range(plantSO.plantGrowthDuration * 0.6f, plantSO.plantGrowthDuration * 1.4f);
    }
}
