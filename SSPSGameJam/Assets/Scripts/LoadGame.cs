using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LoadGame : MonoBehaviour
{
    public List<GameObject> lightList = new List<GameObject>();
    public List<GameObject> audioList = new List<GameObject>();
    public List<GameObject> cameraAudioList = new List<GameObject>();

    private float sliderIntensityValue;
    

    private void Start()
    {
        SetValuesInComponents();
    }
    private void SetValuesInComponents()
    {

        switch (MenuNav.currentDifficulty)
        {
            case "easy":
                sliderIntensityValue = 3f;
                break;
            case "normal":
                sliderIntensityValue = 1.5f;
                break;
            case "hard":
                sliderIntensityValue = 1f;
                break;
            case "custom":
                sliderIntensityValue = Save.SaveTemplate.sliderValues[0];
                break;
        }

        Save.SaveTemplate.sliderValues[0] = sliderIntensityValue;

        lightList = GameObject.FindGameObjectsWithTag("Light").ToList();
        audioList = GameObject.FindGameObjectsWithTag("Audio").ToList();
        cameraAudioList = GameObject.FindGameObjectsWithTag("MainCamera").ToList();
        audioList.AddRange(cameraAudioList);

        foreach (var go in lightList)
        {
            go.GetComponent<Light2D>().intensity = Save.SaveTemplate.sliderValues[0] / 100;
        }

        foreach (var go in audioList)
        {
            go.GetComponent<AudioSource>().volume = Save.SaveTemplate.sliderValues[1] / 100;
        }
    }
}
