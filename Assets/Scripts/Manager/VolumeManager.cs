using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider AllSlider, BGMSlider, EffectSlider;
    public float AllVolume;
    public float BGMVolume;
    public float EffectVolume;
    public float OriginBGMValume = 1f, OriginEffectValume = 1f;
    public AudioSource[] BGM, Effect;

    // Start is called before the first frame update
    void Start()
    {
        AllVolume = PlayerPrefs.GetFloat("All", 1f);
        BGMVolume = PlayerPrefs.GetFloat("BGM", 1f);
        EffectVolume = PlayerPrefs.GetFloat("Effect", 1f);
        AllSlider.value = AllVolume;
        BGMSlider.value = BGMVolume;
        EffectSlider.value = EffectVolume;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        for(int i = 0; i < BGM.Length; i++)
        {
            BGM[i].volume = OriginBGMValume * AllSlider.value * BGMSlider.value;
        }
        for (int i = 0; i < Effect.Length; i++)
        {
            Effect[i].volume = OriginEffectValume * AllSlider.value * EffectSlider.value;
        }

        AllVolume = AllSlider.value;
        BGMVolume = BGMSlider.value;
        EffectVolume = EffectSlider.value;


        PlayerPrefs.SetFloat("All", AllVolume);
        PlayerPrefs.SetFloat("BGM", BGMVolume);
        PlayerPrefs.SetFloat("Effect", EffectVolume);
    }
}
