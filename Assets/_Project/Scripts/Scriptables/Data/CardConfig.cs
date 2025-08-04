using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Config/Card Config")]
public class CardConfig : ScriptableObject
{
    public List<CardType> _uniqueCardTypes;
    
}
