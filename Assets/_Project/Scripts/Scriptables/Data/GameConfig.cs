using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Responsible for having all level configs(all levels)
[CreateAssetMenu(menuName = "Scriptables/Config/Game Config")]
public class GameConfig : ScriptableObject
{
    public List<LevelConfig> leveConfigs;
}
