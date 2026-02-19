using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] public GameObject cubePrefab;

    [SerializeField] public int Width;
    [SerializeField] public int Height;
    [SerializeField] public int Large;
    public float detail;
    public int seed;

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int x = 0; x < Width; x++)
        {
            
            for (int z = 0; z < Large; z++)
            {
                Height = (int)(Mathf.PerlinNoise((x / 2 + seed) / detail, (z / 2 + seed) / detail) * detail);

                for (int y = 0; y < Height; y++)
                {
                    Instantiate(cubePrefab, new Vector3(x,y,z), Quaternion.identity);
                }
            }
        }
    }
}
