using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public Text musicText;
    public Text sfxText;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // Get music muted state from PlayerPrefs and set the mute state of musicSource
        int musicMuted = PlayerPrefs.GetInt("musicMuted", 0);
        musicSource.mute = musicMuted == 1;

        // Get sfx muted state from PlayerPrefs and set the mute state of sfxSource
        int sfxMuted = PlayerPrefs.GetInt("sfxMuted", 0);
        sfxSource.mute = sfxMuted == 1;

        // musicText.text = "Off";
        // sfxText.text = "Off";
        musicText.text = musicSource.mute ? "On" : "Off";
        sfxText.text = sfxSource.mute ? "On" : "Off";
    }
    private void Start() {
        PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else{
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        PlayerPrefs.SetInt("musicMuted", musicSource.mute ? 1 : 0);
        musicText.text = (musicSource.mute == true) ? "On" : "Off";
    }
    public void ToggleSFX(){
        sfxSource.mute = !sfxSource.mute;
        // sfxSource.mute = (sfxSource.mute == false) ? true : false;
        PlayerPrefs.SetInt("sfxMuted", sfxSource.mute ? 1 : 0);
        sfxText.text = (sfxSource.mute == true) ? "On" : "Off";
    }

}
