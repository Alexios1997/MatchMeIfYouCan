using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameEvent _OnWin;
    [SerializeField] private CardListVariable _cardListVariable;

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
            Debug.Log("WIN!");
        }
    }
    
    public void Win()
    {
        
        // Play ANimation Panel
    }
    
}
