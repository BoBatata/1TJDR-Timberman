using UnityEngine;

public enum SFXAudioType
{
    OnClick,
    Hit,
    Hurt
}

[RequireComponent(typeof(AudioSource))]

public class SFXAudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sfxAudios;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void ChooseSoundType(SFXAudioType audioType)
    {
        switch (audioType)
        {
            case SFXAudioType.OnClick:
                PlaySound(sfxAudios[0]);
                break;
            case SFXAudioType.Hit:
                PlaySound(sfxAudios[1]);
                break;
            case SFXAudioType.Hurt:
                PlaySound(sfxAudios[2]);
                break;
        }
    }


    private void PlaySound(AudioClip audioType)
    {
        audioSource.clip = audioType;
        audioSource.Play();
    }
}
