using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptables/Card Type")]
public class CardType : ScriptableObject
{
    // Card Name
    public string name;
    // Card front Sprite
    public Sprite cardFront;
    // Card back Sprite
    public Sprite cardBack;
}
