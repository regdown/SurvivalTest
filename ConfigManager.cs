```
using UnityEngine;
using System.IO;

public class ConfigManager : MonoBehaviour
{
    public static string ConfigValue1;
    public static int ConfigValue2;

    void Awake()
    {
        LoadConfig();
    }

    void LoadConfig()
    {
        string path = Application.dataPath + "/config.env";
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split('=');
                if (parts.Length == 2)
                {
                    switch (parts[0])
                    {
                        case "ConfigValue1":
                            ConfigValue1 = parts[1];
                            break;
                        case "ConfigValue2":
                            ConfigValue2 = int.Parse(parts[1]);
                            break;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Config file not found: " + path);
        }
    }
}
```