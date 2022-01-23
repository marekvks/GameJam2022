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

    private void Start()
    {
        SetValuesInComponents();
    }
    private void SetValuesInComponents()
    {

        lightList = GameObject.FindGameObjectsWithTag("Light").ToList();
        audioList = GameObject.FindGameObjectsWithTag("Audio").ToList();
        cameraAudioList = GameObject.FindGameObjectsWithTag("MainCamera").ToList();
        audioList.AddRange(cameraAudioList);

        foreach (var go in lightList)
        {
            go.GetComponent<Light2D>().intensity = Save.sliderValues[0] / 100;
        }

        foreach (var go in audioList)
        {
            go.GetComponent<AudioSource>().volume = Save.sliderValues[1] / 100;
        }
    }
}
