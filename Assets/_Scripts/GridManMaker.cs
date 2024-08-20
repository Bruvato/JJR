using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GridManMaker : MonoBehaviour{ 
    [SerializeField] private float baseGridSpacing = 1f;
    [SerializeField] private Color gridColor = Color.white;
    [SerializeField] private float lineWidth = 0.02f;
    [SerializeField] private float gridExtensionFactor = 1.5f; 
    [SerializeField] private float cullDistance = 20f;

    private List<GameObject> gridLines = new List<GameObject>();

    private void Start() {
        AdjustGrid();
    }

    private void Update() {
        AdjustGrid();
    }

    void AdjustGrid() {
        foreach (GameObject line in gridLines) {
            line.SetActive(false);
        }

        Vector3 playerScale = Player.Instance.GetScale();
        float maxPlayerDimension = Mathf.Max(playerScale.x, playerScale.y, playerScale.z);
        float adjustedGridSpacing = Mathf.Max(baseGridSpacing, maxPlayerDimension / (gridExtensionFactor * 2f));
    
        int gridSizeX = Mathf.CeilToInt(playerScale.x * gridExtensionFactor);
        int gridSizeY = Mathf.CeilToInt(playerScale.y * gridExtensionFactor);
        int gridSizeZ = Mathf.CeilToInt(playerScale.z * gridExtensionFactor);

        int maxGuy =  Math.Max(Math.Max(gridSizeX,gridSizeY), gridSizeZ);
        int maxGuyLimiter = 500;

        if(maxGuy<= maxGuyLimiter){
            gridSizeX = Math.Max(Math.Max(gridSizeX,gridSizeY), gridSizeZ);
            gridSizeY = Math.Max(Math.Max(gridSizeX,gridSizeY), gridSizeZ);
            gridSizeZ = Math.Max(Math.Max(gridSizeX,gridSizeY), gridSizeZ);
        } else if(maxGuy>maxGuyLimiter){
            gridSizeX =maxGuyLimiter;
            gridSizeY =maxGuyLimiter;
            gridSizeZ =maxGuyLimiter;
        }
        
        Vector3 playerPosition = Player.Instance.transform.position;
        Vector3 playerCornerOffset = new Vector3(
        -playerScale.x * 0.5f,
        -playerScale.y * 0.5f,
        -playerScale.z * 0.5f
        );
        

        float adjustedCullDistance = Mathf.Max(playerScale.x, playerScale.y, playerScale.z)* cullDistance;


        for (int x = -gridSizeX; x <= gridSizeX; x++) {
            for (int z = -gridSizeZ; z <= gridSizeZ; z++) {
                if (Mathf.Abs(x) % gridSizeX == 0 || Mathf.Abs(z) % gridSizeZ == 0) {
                    CreateOrReuseLine(
                        playerPosition + playerCornerOffset + new Vector3(x * adjustedGridSpacing, -gridSizeY * adjustedGridSpacing, z * adjustedGridSpacing),
                        playerPosition + playerCornerOffset +new Vector3(x * adjustedGridSpacing, gridSizeY * adjustedGridSpacing, z * adjustedGridSpacing),
                        adjustedCullDistance
                    );
                }
            }
        }

        for (int y = -gridSizeY; y <= gridSizeY; y++) {
            for (int z = -gridSizeZ; z <= gridSizeZ; z++) {
                if (Mathf.Abs(y) % gridSizeY == 0 || Mathf.Abs(z) % gridSizeZ == 0) {
                    CreateOrReuseLine(
                        playerPosition + playerCornerOffset  +new Vector3(-gridSizeX * adjustedGridSpacing, y * adjustedGridSpacing, z * adjustedGridSpacing),
                        playerPosition + playerCornerOffset +new Vector3(gridSizeX * adjustedGridSpacing, y * adjustedGridSpacing, z * adjustedGridSpacing),
                        adjustedCullDistance
                    );
                }
            }
        }

        for (int x = -gridSizeX; x <= gridSizeX; x++) {
            for (int y = -gridSizeY; y <= gridSizeY; y++) {
                if (Mathf.Abs(x) % gridSizeX == 0 || Mathf.Abs(y) % gridSizeY == 0) {
                    CreateOrReuseLine(
                        playerPosition + playerCornerOffset +new Vector3(x * adjustedGridSpacing, y * adjustedGridSpacing, -gridSizeZ * adjustedGridSpacing),
                        playerPosition + playerCornerOffset +new Vector3(x * adjustedGridSpacing, y * adjustedGridSpacing, gridSizeZ * adjustedGridSpacing),
                        adjustedCullDistance
                    );
                }
            }
        }
    }

    void CreateOrReuseLine(Vector3 start, Vector3 end, float adjustedCullDistance) {
        if (Vector3.Distance(Player.Instance.transform.position, start) > adjustedCullDistance && Vector3.Distance(Player.Instance.transform.position, end) > adjustedCullDistance)
            return; 

        GameObject line = GetPooledLine();
        line.transform.SetParent(transform);

        LineRenderer lr = line.GetComponent<LineRenderer>();
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = gridColor;
        lr.endColor = gridColor;

        line.SetActive(true); 
    }

    GameObject GetPooledLine() {
        foreach (GameObject line in gridLines) {
            if (!line.activeInHierarchy){
                return line; 
            }
        }

        GameObject newLine = new GameObject("GridLine");
        newLine.AddComponent<LineRenderer>();
        gridLines.Add(newLine);
        return newLine;
    }
}
