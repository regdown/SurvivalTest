```csharp
using UnityEngine;

public class WorldGeneratorAI : MonoBehaviour
{
    public int worldWidth = 64;
    public int worldHeight = 64;
    public GameObject[] terrainPrefabs;
    public GameObject[] featurePrefabs;

    private void Start()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        for (int x = 0; x < worldWidth; x++)
        {
            for (int y = 0; y < worldHeight; y++)
            {
                Vector3 position = new Vector3(x, 0, y);

                // Select terrain based on a noise function
                float perlinValue = Mathf.PerlinNoise(x * 0.1f, y * 0.1f);
                GameObject terrain = SelectTerrain(perlinValue);

                Instantiate(terrain, position, Quaternion.identity);

                // Add features like trees or rocks with a chance
                if (Random.value < 0.1f)
                {
                    GameObject feature = SelectFeature(perlinValue);
                    Instantiate(feature, position + Vector3.up, Quaternion.identity);
                }
            }
        }
    }

    private GameObject SelectTerrain(float value)
    {
        // Add logic to choose different terrains
        if (value < 0.3f)
            return terrainPrefabs[0]; // e.g., sand
        else if (value < 0.6f)
            return terrainPrefabs[1]; // e.g., grass
        else
            return terrainPrefabs[2]; // e.g., stone
    }

    private GameObject SelectFeature(float value)
    {
        // Add logic to choose different features
        if (value < 0.3f)
            return featurePrefabs[0]; // e.g., cactus
        else if (value < 0.6f)
            return featurePrefabs[1]; // e.g., tree
        else
            return featurePrefabs[2]; // e.g., rock
    }
}
```

Этот код добавляет разнообразие в генерацию мира, используя Perlin Noise и случайные значения для генерации различных типов рельефа и особенностей. Обновите скрипт, чтобы добавить желаемые элементы окружения и особенности!