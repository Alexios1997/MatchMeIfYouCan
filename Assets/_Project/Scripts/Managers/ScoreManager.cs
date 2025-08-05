using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class ScoreManager : MonoBehaviour
{
    [Header("Injected Dependencies")]
    [Space]
    [Header("GameObjects")]
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _turnText;
    [Space]
    [Header("Variables")]
    [SerializeField] private int _score;
    [SerializeField] private int _turns;
    [SerializeField] private IntVariable _currentLevel;
    
    // The instance of Save Data
    private SaveData _currentSave;
    
    // Saving Score and Level
    private void Awake()
    {
        _currentSave = SaveManager.Load();
        if (_currentSave == null)
        {
            Debug.Log("Nothing yet");
            _score = 0;
            _currentLevel.value = 0;
        }
        else
        {
            _score = _currentSave.highScore;
            _currentLevel.value =  _currentSave.level;
        }
        _turns = 0;
        DisplayTurns();
        DisplayScore();
    }

    // Update Score
    public void UpdateScore()
    {
        _score++;
        DisplayScore();
        
    }

    // Display Score
    private void DisplayScore()
    {
        _scoreText.text = "Score: " + _score;
    }

    // Update Turns
    public void UpdateTurn()
    {
        _turns++;
        DisplayTurns();
    }
    
    // Display Turns
    private void DisplayTurns()
    {
        _turnText.text = "Turns: " + _turns;
    }

    // Wait 1 second and save Level and score
    public void Save()
    {
        StartCoroutine(WaitAndSave());

    }

    IEnumerator WaitAndSave()
    {
        yield return new WaitForSeconds(1f);
        _currentLevel.value++;
        _currentSave.highScore = _score;
        _currentSave.level = _currentLevel.value;
        SaveManager.Save(_currentSave);
    }
    
}
