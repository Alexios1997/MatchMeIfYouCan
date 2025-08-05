using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Config/Game Config")]
public class GameConfig : ScriptableObject
{
    public List<LevelConfig> leveConfigs;
}
