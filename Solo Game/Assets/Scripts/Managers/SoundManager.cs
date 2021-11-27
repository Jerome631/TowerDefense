using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Manages all the sounds, inherits from singleton to make the class into a singleton
/// </summary>
public class SoundManager : Singleton<SoundManager>
{
    /// <summary>
    /// A reference to the audios source
    /// </summary>
    [SerializeField]
    private AudioSource musicSource;

    /// <summary>
    /// A reference to the sfx Audiosource
    /// </summary>
    [SerializeField]
    private AudioSource sfxSource;

    /// <summary>
    /// A dictionary for all the audio clips
    /// </summary>
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    // Use this for initialization
    void Start()
    {
        //Instantiates the audioclips array by loading all audioclips from the assetfolder
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio") as AudioClip[];

        //Stores all the audio clips
        foreach (AudioClip clip in clips)
        {
            audioClips.Add(clip.name, clip);
        }
    }

    /// <summary>
    /// Plays an sfx sound
    /// </summary>
    /// <param name="name"></param>
    public void PlaySFX(string name)
    {
        //Plays the clip once
        sfxSource.PlayOneShot(audioClips[name]);
    }
}
