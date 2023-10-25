using UnityEngine;

public enum AudioType
{
    Enviroment,
    SFX
}

[RequireComponent(typeof(AudioSource))]

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private EnviromentAudioManager enviromentAudio;
    [SerializeField] private SFXAudioManager sfxAudio;

    public void PlayEnviromentAudioByType(EnviromentAudioType audioType)
    {
        enviromentAudio.PlaySoundByType(audioType);
    }

    public void PlaySFXAudioByType(SFXAudioType audioType)
    {
        sfxAudio.PlaySoundByType(audioType);
    }
}
