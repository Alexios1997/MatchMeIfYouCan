using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _turnText;

    [SerializeField] private int _score;
    [SerializeField] private int _turns;
    [SerializeField] private IntVariable _currentLevel;
    
    private SaveData _currentSave;
    
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

    public void UpdateScore()
    {
        _score++;
        DisplayScore();
        
    }

    private void DisplayScore()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void UpdateTurn()
    {
        _turns++;
        DisplayTurns();
    }
    
    private void DisplayTurns()
    {
        _turnText.text = "Turns: " + _turns;
    }

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
