using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public InputManager inputManager;

    [SerializeField] private AudioSystem audioSystem;

    private void Awake()
    {
        #region Singleton
        if(instance == null) 
        { 
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion

        inputManager = new InputManager();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        PlayEnviromentAudioByType(EnviromentAudioType.Menu);
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
