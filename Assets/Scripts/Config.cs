using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Config : MonoBehaviour
{
    int StateMusic = 0;
    [SerializeField] Button Normal, Ultra;
    [SerializeField] AudioSource[] Audiosources;
    [SerializeField] Image[] UIimages;
    [SerializeField] Slider[] SoundSliders;
    [SerializeField] AudioMixer GlobalAudioMixer;
    [SerializeField] PostProcessVolume Effects;
    public Slider Sensibilit; 
    string MusicVolume = "MusicVolume", EffectsVolume = "EffectsVolume";

    private void Awake()
    {
        LoadConfig();
        if(PlayerPrefs.GetFloat("Sens") != 0)
        {
            Sensibilit.value = (PlayerPrefs.GetFloat("Sens"));
        }
    }
   
    public void Start()
    {
        if(PlayerPrefs.GetInt("Graphics") != 0)
        {
            Normal.interactable = true;
            Ultra.interactable = false;
        }
        else
        {
            Normal.interactable = false;
            Ultra.interactable = true;
         
        }
    }
    public void SoundCheck()
    {
        Audiosources[1].Play();
            
    }
    public void MuteMusic()
    {

        if (StateMusic != 0)
        {
            Audiosources[0].volume = 100;
            UIimages[0].color = Color.white;
            StateMusic++;
        }
        else
        {
            Audiosources[0].volume = 0;
            UIimages[0].color = Color.red;
            StateMusic--;
        }

    }
    public void Update()
    {
        SetMusicValue();
        Senset();
    }
    public void Senset()
    {
        PlayerPrefs.SetFloat("Sens", Sensibilit.value);
        PlayerPrefs.Save();
    }
    public void SetMusicValue()
    {
        GlobalAudioMixer.SetFloat(MusicVolume, Mathf.Log10(SoundSliders[0].value) * 20);
        GlobalAudioMixer.SetFloat(EffectsVolume, Mathf.Log10(SoundSliders[1].value) * 20);
        PlayerPrefs.SetFloat("MusicValue",SoundSliders[0].value);
        PlayerPrefs.SetFloat("EffectsVale", SoundSliders[1].value);
        PlayerPrefs.Save();
    }

    public void SetGraphics(int graphiclevel)
    {
        if (graphiclevel == 0)
        {
            Effects.enabled = false;
            Normal.interactable = false;
            Ultra.interactable = true;
            PlayerPrefs.SetInt("Graphics", 0);
            PlayerPrefs.Save();
        }
        if (graphiclevel == 1)
        {
            Effects.enabled = true;
            Normal.interactable = true;
            Ultra.interactable = false;
            PlayerPrefs.SetInt("Graphics", 1);
            PlayerPrefs.Save();
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }

    public void LoadConfig()
    {

        int Graficos = PlayerPrefs.GetInt("Graphics");
        if(Graficos != 0)
        {
            Effects.enabled = true;
        }
        float SaveSound = PlayerPrefs.GetFloat("MusicValue");
        if (SaveSound != 0)
        {
            SoundSliders[0].value = PlayerPrefs.GetFloat("MusicValue");
            SoundSliders[1].value = PlayerPrefs.GetFloat("EffectsVale");
        }
        else
        {

            SoundSliders[0].value = 100;
            SoundSliders[1].value = 100;
        }
      
    }
}
