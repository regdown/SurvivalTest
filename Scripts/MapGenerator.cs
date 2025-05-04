```csharp
using UnityEngine;

// Enum для определения типов биомов
public enum BiomeType
{
    Grassland,
    Desert,
    Forest,
    Mountain
}

public class MapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float scale;
    public int octaves;
    public float persistence;
    public float lacunarity;
    public Vector2 offset;

    public TerrainType[] regions;

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, scale, octaves, persistence, lacunarity, offset);

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];
                BiomeType biome = DetermineBiome(currentHeight);
                ApplyTile(x, y, biome);
            }
        }
    }

    private BiomeType DetermineBiome(float height)
    {
        if (height < 0.3f)
        {
            return BiomeType.Desert;
        }
        else if (height < 0.5f)
        {
            return BiomeType.Grassland;
        }
        else if (height < 0.7f)
        {
            return BiomeType.Forest;
        }
        else
        {
            return BiomeType.Mountain;
        }
    }

    private void ApplyTile(int x, int y, BiomeType biome)
    {
        GameObject tile = new GameObject($"Tile_{x}_{y}");
        tile.transform.position = new Vector3(x, 0, y);
        switch (biome)
        {
            case BiomeType.Grassland:
                // Применить тайл для лугов
                break;
            case BiomeType.Desert:
                // Применить тайл для пустыни
                break;
            case BiomeType.Forest:
                // Применить тайл для леса
                break;
            case BiomeType.Mountain:
                // Применить тайл для гор
                break;
        }
    }
}
```