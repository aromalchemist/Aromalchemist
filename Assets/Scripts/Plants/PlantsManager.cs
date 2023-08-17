using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantsManager : Singleton<PlantsManager>
{
    [SerializeField] private Tilemap plantsTilemap;

    [SerializeField] private List<PlantSO> plantsSO;

    private List<PlantTile> plantTiles;

    private void Awake()
    {
        plantTiles = new List<PlantTile>();
    }

    private void Update()
    {
        foreach (PlantTile tile in plantTiles)
        {
            if (!tile.harvestable)
            {
                tile.growthDuration -= Time.deltaTime;

                if (tile.growthDuration <= 0f)
                {
                    tile.spriteIndex++;
                    tile.tile.sprite = tile.plantSO.plantSprites[tile.spriteIndex];

                    if (tile.spriteIndex == tile.plantSO.plantSprites.Length - 1)
                    {
                        tile.harvestable = true;
                    }
                    else
                    {
                        tile.RandomizeGrowthDuration();
                    }

                    plantsTilemap.RefreshAllTiles();
                }
            }
        }
    }

    public void CreatePlant(Vector3Int _tilePosition)
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();

        PlantTile plantTile = new PlantTile(plantsSO[0], tile);
        plantTiles.Add(plantTile);

        plantsTilemap.SetTile(_tilePosition, tile);
        plantsTilemap.RefreshAllTiles();
    }
}
