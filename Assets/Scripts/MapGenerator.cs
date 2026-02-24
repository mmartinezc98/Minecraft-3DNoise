using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Prefabs de cubos con materiales")]
    [SerializeField] public GameObject waterPrefab;
    [SerializeField] public GameObject sandPrefab;
    [SerializeField] public GameObject grassPrefab;
    [SerializeField] public GameObject dirtPrefab;
    [SerializeField] public GameObject stonePrefab;
    [SerializeField] public GameObject snowPrefab;

    [Header("Nivel del agua")]
    public int waterLevel = 3;   // Nivel global del agua




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
                    GameObject prefabToUse;


                    // Selección del bloque según altura
                    if (y < 3)
                        prefabToUse = sandPrefab;          //arena
                    else if (y < 6)
                        prefabToUse = grassPrefab;         //cesped
                    else if (y < 10)
                        prefabToUse = dirtPrefab;          //tierra
                    else if (y < 16)
                        prefabToUse = stonePrefab;         //piedra
                    else
                        prefabToUse = snowPrefab;          //nieve

                    Instantiate(prefabToUse, new Vector3(x, y, z), Quaternion.identity);
                }

                // Generamos el agua
                if (Height < waterLevel)
                {
                    Instantiate(waterPrefab, new Vector3(x, waterLevel, z), Quaternion.identity);
                }

            }
        }
        }
    }

