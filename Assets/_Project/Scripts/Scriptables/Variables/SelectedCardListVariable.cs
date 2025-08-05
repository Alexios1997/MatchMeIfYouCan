using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Variables/Selected Card List")]
public class SelectedCardListVariable : ScriptableObject
{
    public List<GameObject> SelectedCards = new List<GameObject>();
    
    public void Clear() => SelectedCards.Clear();
    public void Add(GameObject card) => SelectedCards.Add(card);
    public void Remove(GameObject card) => SelectedCards.Remove(card);
}
