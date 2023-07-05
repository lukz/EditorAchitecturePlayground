using UnityEngine;

namespace Game.Core.Levels
{
    public abstract class LevelController<T, S> : LevelController
        where T : LevelBlueprint 
        where S : GameField
    {
        protected T Blueprint  { get; private set; }

        protected S GameField { get; private set; }

        protected LevelController(T blueprint)
        {
            Blueprint = blueprint;
        }
        
        public override void Setup(GameField gameField)
        {
            GameField = (S)gameField;
            
            var level = GameObject.Instantiate(Blueprint, gameField.transform);
            level.transform.localPosition = Vector3.zero;
            level.Setup();
            
            Setup(GameField);
        }

        protected abstract void Setup(S gameField);
    }

    public abstract class LevelController
    {
        public abstract void Setup(GameField gameField);
    }
}

