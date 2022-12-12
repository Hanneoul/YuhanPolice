using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _Audioinstance;
    public AudioSource BGMaudioSource;
    public AudioSource SFXaudioSource;

    public AudioClip[] bgmClips;
    public AudioClip[] audioClips;
    public static AudioManager Instance
    {
        get
        {
            if (!_Audioinstance)
            {
                _Audioinstance = FindObjectOfType(typeof(AudioManager)) as AudioManager;

                if (_Audioinstance == null)
                    Debug.Log("no Singleton obj");
            }
            return _Audioinstance;
        }
    }
    private void Awake()
    {
        if (_Audioinstance == null)
        {
            _Audioinstance = this;
        }
        else if (_Audioinstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    public void PlayBGM() {
        if(BGMaudioSource.isPlaying) {
            return;
        }
        BGMaudioSource.Play();
    }

    public void StopBGM() {
        BGMaudioSource.Stop();
    }

    public void PlaySFX() {
        if(SFXaudioSource.isPlaying) {
            return;
        }
        SFXaudioSource.Play();
    }

    public void StopSFX() {
        SFXaudioSource.Stop();
    }

    public void bgmchange(int soundNum) {
        BGMaudioSource.Stop();
        BGMaudioSource.clip = bgmClips[soundNum];
        BGMaudioSource.Play();
    }

    public void sfxchange(int soundNum) {
        SFXaudioSource.Stop();
        SFXaudioSource.clip = audioClips[soundNum];
        SFXaudioSource.Play();
    }
}
