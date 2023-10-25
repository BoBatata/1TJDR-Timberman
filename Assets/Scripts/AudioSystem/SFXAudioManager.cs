using UnityEngine;

public enum SFXAudioType
{
    OnClick,
    Hit,
    Hurt
}

[RequireComponent(typeof(AudioSource))]

public class SFXAudioManager : AudioABS
{
    public void PlaySoundByType(SFXAudioType audioType)
    {
        switch (audioType) 
        { 
            case SFXAudioType.OnClick:
                PlaySound(audioClips[0]);
                break;
            case SFXAudioType.Hit:
                PlaySound(audioClips[1]);
                break;
            case SFXAudioType.Hurt:
                PlaySound(audioClips[2]);
                break;
        }
    }
}
