using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    public string saveFileName = "SaveFile";
    private string m_Path;

    // Singleton
    private static Save Instance;

    // Static = easy to access, reference to our save.
    public static SaveTemplate SaveTemplate;

    private void Awake()
    {
        // Check if there is already a reference to this script.
        if (Instance != null && Instance != this)
        {
            // Don't want a second instance.
            Destroy(gameObject);
            return;
        }

        // Otherwise, set the instance to this to keep track of the current singleton.
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Set the current path to the save file.
        m_Path = Application.persistentDataPath + "/" + saveFileName + ".json";

        if (!File.Exists(m_Path))
        {
            // Create a default SaveTemplate, {} for quickly adding values.
            SaveTemplate defaultSaveTemplate = new SaveTemplate
            {
                sliderValues = new List<float> { 1f, 100f, 4.8f },
                monsterSpeed = MonsterAI.monsterSpeed

            };

            // Turn the default SaveTemplate into a JSON string.
            string defaultJson = JsonUtility.ToJson(defaultSaveTemplate);

            // Write the JSON into the save file.
            File.WriteAllText(m_Path, defaultJson);

            // Set the current SaveTemplate to the default one.
            SaveTemplate = defaultSaveTemplate;
        }
        else
        {
            // Grab the JSON string from the save file.
            string saveJson = File.ReadAllText(m_Path);

            // Set the current SaveTemplate to the de-serialized JSON string.
            SaveTemplate = JsonUtility.FromJson<SaveTemplate>(saveJson);
        }
    }

    private void OnApplicationQuit()
    {
        string saveJson = JsonUtility.ToJson(SaveTemplate);

        File.WriteAllText(m_Path, saveJson);
    }
}

// Have to add System.Serializable so Unity knows you can turn this into JSON.
[System.Serializable]
public class SaveTemplate
{
    // Template values.
    public List<float> sliderValues;
    public float monsterSpeed;
}