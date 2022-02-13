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
                Save.SaveTemplate.sliderValues[index] = sliders[index].value;
                texts[index].text = sliders[index].value + "%";
                break;
            case 1:
                Save.SaveTemplate.sliderValues[index] = sliders[index].value;
                texts[index].text = sliders[index].value + "%";
                break;
            case 2:
                Save.SaveTemplate.sliderValues[index] = sliders[index].value;
                texts[index].text = (Mathf.Round((sliders[index].value / 4.8f) * 100)).ToString() + "%";
                break;

        }
        
        Save.SaveTemplate.sliderValues[index] = sliders[index].value;
    }

    public void LoadFromSaveStorage(int index)
    {
        sliders[index].value = Save.SaveTemplate.sliderValues[index];

        if (index == 2)
        {
            texts[index].text = (Mathf.Round((Save.SaveTemplate.sliderValues[index] / 4.8f) * 100)).ToString() + "%";
            return;
        }

        texts[index].text = Save.SaveTemplate.sliderValues[index] + "%";

    }

}
