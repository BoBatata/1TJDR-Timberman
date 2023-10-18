using UnityEngine;

public enum EnviromentAudioType
{
    Menu,
    Gameplay,
    GameOver
}

[RequireComponent(typeof(AudioSource))]

public class EnviromentAudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] enviromentAudios;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void ChooseSoundType(EnviromentAudioType audioType)
    {
        switch (audioType) 
        { 
            case EnviromentAudioType.Menu:
                PlaySound(enviromentAudios[0]);
                break;
            case EnviromentAudioType.Gameplay:
                PlaySound(enviromentAudios[1]);
                break;
        }
    }

    private void PlaySound(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }


}
