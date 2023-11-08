using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public InputManager inputManager;
    [SerializeField] private AudioSystem audioSystem;
    [SerializeField] private UIManager uiManager;
    [SerializeField] public TrunkPool trunkPool;
    [SerializeField] private UIGameOver gameOver;

    private int gameScore;
    private int bestScore;

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
        inputManager.OnHit += IncreaseScore;
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

    private void IncreaseScore(Vector2 touchPos)
    {
        gameScore++;
        uiManager.UpdateGameScore(gameScore);
    }

    public void OnTrunkHit()
    {
        trunkPool.TrunkHit();
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("Scene_Game");
        GameManager.instance.PlayEnviromentAudioByType(EnviromentAudioType.Gameplay);
    }

    public void GameOver()
    {
        inputManager.DisableInput();
        if (gameScore < bestScore)
        {
            bestScore = gameScore;
        }
        gameOver.ShowGameOverUI(gameScore, bestScore);
        Debug.Log("GAME OVER");
    }

    public void SetTrunkPool(TrunkPool pool)
    {
        trunkPool = pool;
    }

    public void SetUIManager(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public void SetGameOverUI(UIGameOver uiGameOver)
    {
        gameOver = uiGameOver;
    }
}
