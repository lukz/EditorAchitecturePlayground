using System;
using System.Collections.Generic;
using System.Linq;
using Game.Core;
using Game.Core.Levels;
using Game.MeshMode;
using Game.SpriteMode;
using UnityEngine;

namespace Scritables
{
    [CreateAssetMenu(fileName = "App", menuName = "Game/Core/App")]
    public class App : ScriptableObject
    {
        [SerializeField] private List<GameModeData> gameModes;
        [SerializeField] private List<LevelBlueprint> levels;

        public LevelBlueprint GetLevel(int index) => levels[index % levels.Count];
        
        public GameModeData GetGameModeData(LevelBlueprint levelBp) => GetGameModeData(GetGameModeForLevel(levelBp));
        
        private GameModeData GetGameModeData(GameMode mode) => gameModes.FirstOrDefault(r => r.GameMode == mode);
        
        public static GameMode GetGameModeForLevel(LevelBlueprint levelBp)
        {
            return levelBp switch
            {
                SpriteModeLevelBlueprint _ => GameMode.SpriteMode,
                MeshModeLevelBlueprint _ => GameMode.MeshMode,
                _ => throw new ArgumentOutOfRangeException(nameof(levelBp))
            };
        }
    
        public LevelController CreateLevelController(LevelBlueprint levelBp) 
        {
            return levelBp switch
            {
                SpriteModeLevelBlueprint level => new SpriteModeLevelController(level),
                MeshModeLevelBlueprint level => new MeshModeLevelController(level),
                _ => throw new ArgumentOutOfRangeException(nameof(levelBp))
            };
        }
    }

    [Serializable]
    public class GameModeData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public GameMode GameMode { get; private set; }
        [field: SerializeField] public GameField GameField { get; private set; }
    }

    public enum GameMode
    {
        SpriteMode = 0, 
        MeshMode = 1, 
    }
}