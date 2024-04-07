using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource,sfxSource;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        PlayMusic("MainTheme");
    }

    public void PlayMusic(string name) {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null) {
            Debug.Log("Music not found");
        } else {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySfx(String name) {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null) {
            Debug.Log("Sfx not found");
        } else {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
