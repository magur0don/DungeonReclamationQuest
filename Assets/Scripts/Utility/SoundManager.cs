using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    public enum SoundType
    {
        Invalide = -1,
        BGM,
        PrimarySE,
        SecondarySE,
        SoundTypesMax
    }
    private AudioSource[] audioSources;

    public enum BGMType
    {
        Invalide = -1,
        StartGameBGM,
        GameMainBGM,
        GameMainResultBGM,
        SoundTypesMax
    }

    [SerializeField]
    private AudioClip[] BGMClips;

    public void SetBGMClips(AudioClip[] audioClips)
    {
        BGMClips = audioClips;
    }


    public enum UISEType
    {
        Invalide = -1,
        Confirm,
    }

    [SerializeField]
    private AudioClip[] uiSEClips;
    public void SetUISEClips(AudioClip[] audioClips)
    {
        uiSEClips = audioClips;
    }
    public enum MainGameSEType
    {
        Invalide = -1,
        IsBuried,
    }

    [SerializeField]
    private AudioClip[] mainGameSEClips;
    public void SetMainGameSEClips(AudioClip[] audioClips)
    {
        mainGameSEClips = audioClips;
    }
    
    public override void Awake()
    {
        audioSources = new AudioSource[(int)SoundType.SoundTypesMax];
        base.Awake();
        for (int i = 0; i < (int)SoundType.SoundTypesMax; i++)
        {
            audioSources[i] = this.gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayBGM(BGMType bgmType)
    {
        // åªç›çƒê∂íÜÇÃâπåπÇ∆ÇÕà·Ç§âπåπÇçƒê∂Ç∑ÇÈèÍçáÇÕçƒê∂Ç≈Ç´ÇÈ
        if (audioSources[(int)SoundType.BGM].clip != BGMClips[(int)bgmType])
        {

            audioSources[(int)SoundType.BGM].clip = BGMClips[(int)bgmType];
            audioSources[(int)SoundType.BGM].Play();
        }
    }

    public void PlayUISE(UISEType SEType)
    {
        if (!audioSources[(int)SoundType.PrimarySE].isPlaying)
        {
            audioSources[(int)SoundType.PrimarySE].PlayOneShot(uiSEClips[(int)SEType]);
        }
        else
        {
            audioSources[(int)SoundType.SecondarySE].PlayOneShot(uiSEClips[(int)SEType]);
        }
    }

    public void PlayMainGameSE(MainGameSEType MainGameSEType)
    {
        if (!audioSources[(int)SoundType.PrimarySE].isPlaying)
        {

            audioSources[(int)SoundType.PrimarySE].PlayOneShot(mainGameSEClips[(int)MainGameSEType]);
        }
        else
        {
            audioSources[(int)SoundType.SecondarySE].PlayOneShot(mainGameSEClips[(int)MainGameSEType]);
        }
    }
}