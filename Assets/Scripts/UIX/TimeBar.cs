using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private float timeToLose;
    [SerializeField, Range(0.1f, 2f)] private float timeToIncrease;
    private Slider slider;
    private bool isGameOver = false;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = timeToLose;
        slider.value = slider.maxValue;
    }

    private void Start()
    {
        GameManager.instance.inputManager.OnHit += IncreaseLoseTime;
    }

    private void Update()
    {
        slider.value -= Time.deltaTime;
        if (slider.value <= slider.minValue && !isGameOver)
        {
            isGameOver = true;
            GameOver();
        }
    }

    private void IncreaseLoseTime(Vector2 touchPosition)
    {
        slider.value += timeToIncrease;
    }

    private void GameOver()
    {
        GameManager.instance.GameOver();
        Debug.LogError("ACABOU O GAME!");
    }
}
