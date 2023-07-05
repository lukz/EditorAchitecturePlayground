using System;
using Game.Core;
using Game.Core.Levels;
using Scritables;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private App app; 
    [SerializeField] private LevelBlueprint debugLevelBlueprint; 
    
    [Header("References")]
    [SerializeField] private UIController uiController; 
    
    private LevelController levelController;
    private int currentLevelIndex;

    void Start()
    {
        SetLevel(0);
    }

    private void OnEnable()
    {
        uiController.OnNext += NextLevel;
        uiController.OnPrev += PrevLevel;
    }

    private void OnDisable()
    {
        uiController.OnNext -= NextLevel;
        uiController.OnPrev -= PrevLevel;
    }
    
    private void NextLevel() => SetLevel(currentLevelIndex + 1);

    private void PrevLevel() => SetLevel(currentLevelIndex + 1);

    private void SetLevel(int levelIndex)
    {
        currentLevelIndex = levelIndex;

        var targetLevel = debugLevelBlueprint ?? app.GetLevel(currentLevelIndex);

        uiController.SetLevel(currentLevelIndex);
        uiController.SetMode(app.GetGameModeData(targetLevel).Name);
        
        Setup(targetLevel);
    }
    
    private void Setup(LevelBlueprint levelBlueprint)
    {
        if(levelBlueprint == null)
            return;
        
        transform.ClearChildren();

        var gameModeData = app.GetGameModeData(levelBlueprint);
        var gameField = Instantiate(gameModeData.GameField, transform);

        levelController = app.CreateLevelController(levelBlueprint);
        levelController.Setup(gameField);
    }
    
    


}
