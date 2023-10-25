using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private AudioSystem audioSystem;

    private void Awake()
    {
        #region Singleton
        if(Instance == null) 
        { 
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        audioSystem.PlayEnviromentAudioByType(EnviromentAudioType.Menu);
    }

    public void PlayEnviromentAudioByType(EnviromentAudioType audioType)
    {
        audioSystem.PlayEnviromentAudioByType(audioType);
    }

    public void PlaySFXAudioByType(SFXAudioType audioType)
    {
        audioSystem.PlaySFXAudioByType(audioType);
    }


}
