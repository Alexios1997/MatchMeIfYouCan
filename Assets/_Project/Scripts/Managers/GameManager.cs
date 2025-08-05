using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameEvent _OnWin;
    [SerializeField] private CardListVariable _cardListVariable;
    [SerializeField] private RectTransform _winPanel;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _winFinalText;
    [SerializeField] private IntVariable _currentLevel;
    [SerializeField] private GameConfig _gameConfig;

    private int counterMatchedCards = 0;
    public void Start()
    {
        counterMatchedCards = 0;
    }
    
    public void CheckRemainingCards()
    {
        counterMatchedCards++;
        if (counterMatchedCards == _cardListVariable.Cards.Count/2)
        {
            _OnWin.Raise();
            Win();
        }
    }
    
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

    public void PlayNext(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
