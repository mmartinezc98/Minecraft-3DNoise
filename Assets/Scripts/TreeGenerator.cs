using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public MapGenerator map;   // referencia al generador del mapa

    [Header("Prefabs de vegetación")]
    public GameObject trunkPrefab;
    public GameObject leafPrefab;

    private void Start()
    {
        GenerateTrees();
    }

    public void GenerateTrees()
    {
        for (int x = 0; x < map.Width; x++)
        {
            for (int z = 0; z < map.Large; z++)
            {
                int height = map.heightMap[x, z];

                // No generar árboles en agua
                if (height < map.waterLevel)
                    continue;

                // Obtener el bloque superior
                GameObject topBlock = map.blockMap[x, height, z];

                if (topBlock == null)
                    continue;

                // Solo generar árboles en grass o dirt
                string tag = topBlock.tag;

                if (tag == "Grass" || tag == "Dirt")
                {
                    GenerateTree(x, height + 1, z);
                }
            }
        }
    }

    private void GenerateTree(int x, int y, int z)
    {
        int trunkHeight = Random.Range(3, 6);

        // Tronco
        for (int i = 0; i < trunkHeight; i++)
        {
            Instantiate(trunkPrefab, new Vector3(x, y + i, z), Quaternion.identity);
        }

        int topY = y + trunkHeight;

        // Copa
        for (int lx = -2; lx <= 2; lx++)
        {
            for (int lz = -2; lz <= 2; lz++)
            {
                if (Mathf.Abs(lx) + Mathf.Abs(lz) <= 3)
                {
                    Instantiate(leafPrefab, new Vector3(x + lx, topY, z + lz), Quaternion.identity);
                }
            }
        }

        // Hoja superior
        Instantiate(leafPrefab, new Vector3(x, topY + 1, z), Quaternion.identity);
    }
}