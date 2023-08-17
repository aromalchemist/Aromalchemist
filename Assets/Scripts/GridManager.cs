using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tilemap backgroundTilemap;
    [SerializeField] private Tilemap plantsTilemap;
    [SerializeField] private Tilemap collidersTilemap;

    private List<PlantTile> plantTiles;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleMouseClick();
        }
    }

    // TEST FOR PLACING PLANTS
    private void HandleMouseClick()
    {
        // Get Mouse Position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // Get Tile Position from Mouse Position
        Vector3Int tilePosition = Vector3Int.FloorToInt(mousePosition);
        TileBase tileBase = plantsTilemap.GetTile(tilePosition);

        // Stop if there is already a Tile
        if (tileBase != null) return;

        // Create Tile
        PlantsManager.Instance.CreatePlant(tilePosition);
    }
}
