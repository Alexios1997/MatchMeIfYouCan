using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Variables/Card List")]
public class CardListVariable : ScriptableObject
{
    public List<GameObject> Cards = new List<GameObject>();
    
    public void Clear() => Cards.Clear();
    public void Add(GameObject card) => Cards.Add(card);
    public void Remove(GameObject card) => Cards.Remove(card);
}
