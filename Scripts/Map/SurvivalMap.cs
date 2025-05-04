```csharp
using UnityEngine;

public class SurvivalMap : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject rockPrefab;
    public GameObject waterPrefab;
    public GameObject animalPrefab;
    public int width = 100;
    public int height = 100;
    public int numberOfTrees = 50;
    public int numberOfRocks = 20;
    public int numberOfWaterPonds = 5;
    public int numberOfAnimals = 10;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 position = new Vector3(Random.Range(0, width), 0, Random.Range(0, height));
            Instantiate(treePrefab, position, Quaternion.identity);
        }

        for (int i = 0; i < numberOfRocks; i++)
        {
            Vector3 position = new Vector3(Random.Range(0, width), 0, Random.Range(0, height));
            Instantiate(rockPrefab, position, Quaternion.identity);
        }

        for (int i = 0; i < numberOfWaterPonds; i++)
        {
            Vector3 position = new Vector3(Random.Range(0, width), 0, Random.Range(0, height));
            Instantiate(waterPrefab, position, Quaternion.identity);
        }

        for (int i = 0; i < numberOfAnimals; i++)
        {
            Vector3 position = new Vector3(Random.Range(0, width), 0, Random.Range(0, height));
            Instantiate(animalPrefab, position, Quaternion.identity);
        }
    }
}
```

Дополнительно, тебе потребуется создать префабы для деревьев, камней и других объектов (как например `treePrefab`, `rockPrefab`, `waterPrefab`, `animalPrefab`) и настроить их в редакторе Unity для получения более реалистичного внешнего вида. Также можешь добавить в префабах анимации, текстуры и освещение для повышения реализма.