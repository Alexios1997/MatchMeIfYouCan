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

    
    private SaveData _currentSave;
    
    private void Start()
    {
        _currentSave = SaveManager.Load();
        if (_currentSave == null)
        {
            _score = 0;
        }
        else
        {
            _score = _currentSave.highScore;
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

    public void SaveScore()
    {
        _currentSave.highScore = _score;
        SaveManager.Save(_currentSave);
    }
    
}
