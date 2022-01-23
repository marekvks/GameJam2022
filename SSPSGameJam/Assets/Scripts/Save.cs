using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public static Save saveStorage;
    public static List<float> sliderValues = new List<float>() { 1f, 100f };

    private void Start()
    {
        if (saveStorage != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        saveStorage = this;

        sliderValues[0] = PlayerPrefs.GetFloat("Brightness", 1f);
        sliderValues[1] = PlayerPrefs.GetFloat("Volume", 100f);

        

    }
}
