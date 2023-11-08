using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private UIGameOver uiGameOverScreen;

    private void Awake()
    {
        playButton.onClick.AddListener(GoToGameScene);
        uiGameOverScreen.gameObject.SetActive(false);
    }

    private void GoToGameScene()
    {
        GameManager.instance.PlaySFXAudioByType(SFXAudioType.OnClick);
        GameManager.instance.ReplayGame();
    }

    public void UpdateGameScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

}
