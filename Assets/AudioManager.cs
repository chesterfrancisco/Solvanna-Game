using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] public Sound[] sfxSoundList;
    public Sound music;
    private Sound _selectedSFX;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        PlayMusic();
    }
    public void PlayMusic()
    {
        _musicSource.clip = music.clip;
        _musicSource.loop = true;
        _musicSource.Play();
    }
    public void PlaySFX(string name)
    {
        foreach (Sound clip in sfxSoundList)
        {
            if (clip.name == name)
            {
                _selectedSFX = clip;
            }
        }
        if (_selectedSFX == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            Debug.Log("Playing " + _selectedSFX.name);
            _sfxSource.PlayOneShot(_selectedSFX.clip);
        }
    }

}