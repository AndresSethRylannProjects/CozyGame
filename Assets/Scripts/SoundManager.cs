using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider volumeSlider;
    void Start()
    {
        if(!PlayerPrefs.HasKey("VolumeLevel"))
        {
            PlayerPrefs.SetFloat("VolumeLevel", 0.1f);
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("VolumeLevel", volumeSlider.value);
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeLevel");
    }
}
