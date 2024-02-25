using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Music")]
    public AudioSource music_source;
    public AudioClip music_Bg;
    [Header("Sound")]
    public AudioSource[] sound_sources;
    public AudioSource[] loopSources;
    private Queue<AudioSource> queue_sources;
    private Queue<AudioSource> _queueLoops;
    private Dictionary<AudioClip, AudioSource> _dicLoop = new();

    [Header("UI Sound")]
    public AudioClip click;
   
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            queue_sources = new Queue<AudioSource>(sound_sources);
            _queueLoops = new Queue<AudioSource>(loopSources);
        }
    }
 
    public void OnEnable()
    {
        UpdateMute();
    }

    public void UpdateMute()
    {
        ChangeSound();
        ChangeMusic();
    }

    public void PlayShot(AudioClip clip, float volume = 1f)
    {
        var source = queue_sources.Dequeue();
        source.volume = volume;
        source.PlayOneShot(clip);
        queue_sources.Enqueue(source);
    }
    public void PlayVibrate()
    {
        if (!PrefData.turnOffVibrate)
        {
            return;
        }

    }

    public void PlayLoop(AudioClip clip, float volume = 1f)
    {
        if (clip == null || _dicLoop.ContainsKey(clip))
        {
            return;
        }
        var loopSource = _queueLoops.Dequeue();
        loopSource.volume = volume;
        loopSource.clip = clip;
        loopSource.Play();
        _dicLoop.Add(clip, loopSource);
    }



    public void ChangeSound()
    {
        foreach (var sound in sound_sources)
        {
            sound.mute = !PrefData.turnOffSound;
        }
        foreach (var sound in loopSources)
        {
            sound.mute = !PrefData.turnOffSound;
        }
    }
    public void ChangeMusic()
    {
        music_source.mute = !PrefData.turnOffMusic;
    }
}
