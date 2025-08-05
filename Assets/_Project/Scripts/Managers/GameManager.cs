using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("Injected Dependencies")]
    [Space]
    [Header("Events")]
    [SerializeField] private GameEvent _OnWin;
    [Space]
    [Header("Variables")]
    [SerializeField] private CardListVariable _cardListVariable;
    [SerializeField] private IntVariable _currentLevel;
    [SerializeField] private GameConfig _gameConfig;
    [Space]
    [Header("Game Objects")]
    [SerializeField] private RectTransform _winPanel;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _resetButton;
    [SerializeField] private GameObject _winFinalText;

    // Private and not SerializedFields
    private int counterMatchedCards = 0;
    
    // On Start we check if Current level is bigger than 
    // Game config levels and ask the user if he
    // wants to reset and play again
    public void Start()
    {
        if (_currentLevel.value > _gameConfig.leveConfigs.Count - 1)
        {
            _resetButton.SetActive(true);
        }
        else
        {
            _resetButton.SetActive(false);
        }
        
        counterMatchedCards = 0;
    }
    
    // Checking Remaining Cards 
    // So we know when he has won
    public void CheckRemainingCards()
    {
        counterMatchedCards++;
        if (counterMatchedCards == _cardListVariable.Cards.Count/2)
        {
            _OnWin.Raise();
            Win();
        }
    }
    
    // Win Function used displaying the Final text if reached Last level
    // OR next button to play next level
    public void Win()
    {
        if (_currentLevel.value >= (_gameConfig.leveConfigs.Count - 1))
        {
            _winFinalText.SetActive(true);
            _nextButton.SetActive(false);
        }
        else
        {
            _winFinalText.SetActive(false);
            _nextButton.SetActive(true);
        }
        
        StartCoroutine(StartMovingWinPanel());
    }

    // Function to move with ANimation UI Utility the Win Panel
    IEnumerator StartMovingWinPanel()
    {
        yield return AnimationUI.TweenFloat(
            _winPanel.anchoredPosition.x, 
            0f, 
            2f,
            val => {
                Vector2 anchoredPos = _winPanel.anchoredPosition;
                anchoredPos.x = val;
                _winPanel.anchoredPosition = anchoredPos;
            },
            AnimationUI.EaseInOutCubic
        );
    }

    // Play Next Level
    public void PlayNext(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    // Exit Game
    public void ExitGame()
    {
        Application.Quit();
    }
    
    // Reset and Play Again
    public void ResetGame()
    {
       SaveManager.DeleteSave();
       SceneManager.LoadScene("Game_Scene");
    }
    
}
