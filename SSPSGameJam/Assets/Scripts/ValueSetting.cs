using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ValueSetting : MonoBehaviour
{
    public List<Slider> sliders = new List<Slider>();
    public List<TMP_Text> texts = new List<TMP_Text>();

    private void Start()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            LoadFromSaveStorage(i);
        }   
    }

    public void ValueChanged(int index)
    {
        switch (index)
        {
            case 0:
                PlayerPrefs.SetFloat("Brightness", sliders[0].value);
                break;
            case 1:
                PlayerPrefs.SetFloat("Volume", sliders[1].value);
                break;

        }
        texts[index].text = sliders[index].value + "%";
        Save.sliderValues[index] = sliders[index].value;
    }

    public void LoadFromSaveStorage(int index)
    {
        sliders[index].value = Save.sliderValues[index];
        texts[index].text = Save.sliderValues[index] + "%";
    }

}
