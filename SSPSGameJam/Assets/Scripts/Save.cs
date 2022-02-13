using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    // The save file name, can be changed in the inspector.
    public string saveFileName = "SaveFile";
    // Private variable that holds the path to the save file.
    private string m_Path;

    // A reference to the Singleton, so that we only have 1 instance of this script in the entire game.
    private static Save Instance;

    // A reference to the current save, in an object we can read, made static for easy access.
    public static SaveTemplate SaveTemplate;

    // This runs only once, and that's on when the object itself is initialized, not enabled.
    private void Awake()
    {
        // Check if there is already a reference to this script.
        if (Instance != null && Instance != this)
        {
            // If there is, destroy this gameObject, we don't want another save manager in the game.
            Destroy(gameObject);
            return;
        }

        // Otherwise, set the instance to this to keep track of the current singleton.
        Instance = this;
        // And make sure to not destroy the object between scenes.
        DontDestroyOnLoad(gameObject);

        // Set the current path to the save file.
        m_Path = Application.persistentDataPath + "/" + saveFileName + ".json";

        // If the save file DOESN'T exist.
        if (!File.Exists(m_Path))
        {
            // Create a default SaveTemplate, we use {} for quickly adding the values, instead of the .valueName.
            SaveTemplate defaultSaveTemplate = new SaveTemplate
            {
                // Your default values, don't forget to change them if you change your mind.
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
        // If the file DOES exist.
        else
        {
            // Grab the JSON string from the save file.
            string saveJson = File.ReadAllText(m_Path);

            // Set the current SaveTemplate to the de-serialized JSON string.
            SaveTemplate = JsonUtility.FromJson<SaveTemplate>(saveJson);
        }
    }

    // When the game quits, we want to save.
    private void OnApplicationQuit()
    {
        // Create a JSON string from the current SaveTemplate.
        string saveJson = JsonUtility.ToJson(SaveTemplate);

        // Save the JSON string to the file save.
        File.WriteAllText(m_Path, saveJson);
    }
}

// Have to add System.Serializable so Unity knows you can turn this into JSON. This is your save structure.
[System.Serializable]
public class SaveTemplate
{
    // The values you want to save between game sessions.
    public List<float> sliderValues;
    public float monsterSpeed;
}