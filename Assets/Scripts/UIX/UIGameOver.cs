using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Button replayButton;

    private void Awake()
    {
        replayButton.onClick.AddListener(PlayAgain);
        GameManager.instance.SetGameOverUI(this);
        this.gameObject.SetActive(true);
    }

    private void PlayAgain()
    {
        GameManager.instance.PlaySFXAudioByType(SFXAudioType.OnClick);
        GameManager.instance.ReplayGame();
    }

    public void UpdateScoreText(int currentScore, int bestScore)
    {
        currentScoreText.text = currentScore.ToString();
        bestScoreText.text = bestScore.ToString();
    }
    public void ShowGameOverUI(int currentSCore, int bestScore)
    {
        this.gameObject.SetActive(true);
        this.UpdateScoreText(currentSCore, bestScore);
    }

}
