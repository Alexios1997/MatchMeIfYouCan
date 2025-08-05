using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private SelectedCardListVariable  _selectedCardListVariable;
    [SerializeField] private GameEvent  _OnMatched;
    [SerializeField] private GameEvent  _OnMismatched;
    
    
    private void Start()
    {
        _selectedCardListVariable.Clear();
    }


    public void CheckPair()
    {
        
        if (_selectedCardListVariable.SelectedCards.Count < 2) return;

        Card card1 = _selectedCardListVariable.SelectedCards[0].GetComponent<Card>();
        Card card2 = _selectedCardListVariable.SelectedCards[1].GetComponent<Card>();
        if (card1.GetCurrentCardType() ==
            card2.GetCurrentCardType())
        {
            StartCoroutine(StartFlipping(card1,card2,true));
            _OnMatched.Raise();
        }
        else
        {
            StartCoroutine(StartFlipping(card1,card2,false));
            _OnMismatched.Raise();
        }
    }

    IEnumerator StartFlipping(Card card1, Card card2, bool matched)
    {
        yield return new WaitForSeconds(1f);
        if (matched)
        {
            card1.DisableCard();
            card2.DisableCard();
        }
        else
        {
            card1.FlipCard();
            card2.FlipCard();
        }
        _selectedCardListVariable.SelectedCards.Clear();
        
    }
   
}
