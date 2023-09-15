using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] Music;
    public AudioClip ButtonMusic;
    AudioSource MusicManager;
    AudioSource ClipSound;
    // Start is called before the first frame update
    private void Start()
    {
   
        MusicManager = GetComponent<AudioSource>();
        ClipSound = transform.GetChild(0).GetComponent<AudioSource>();

    }
    public void PopSoundEffect()
    {
        ClipSound.clip = ButtonMusic;
        ClipSound.Play();
    }
    public void PlaySong(int Song)
    {
        switch(Song)
        {
            case 1:
                MusicManager.clip = Music[0];
                MusicManager.Play();
            break;
            case 2:
                MusicManager.clip = Music[1];
                MusicManager.Play();
                break;
            case 3:
                MusicManager.clip = Music[2];
                MusicManager.Play();
                break;
            case 4:
                MusicManager.clip = Music[3];
                MusicManager.Play();
                break;
            case 5:
                MusicManager.clip = Music[4];
                MusicManager.Play();
                break;
        }
            
    }
}
