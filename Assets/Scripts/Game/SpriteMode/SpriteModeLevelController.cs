using Game.Core.Levels;
using Game.SpriteMode;

namespace Game.MeshMode
{
    public class SpriteModeLevelController : LevelController<SpriteModeLevelBlueprint, SpriteModeGameField>
    {
        public SpriteModeLevelController(SpriteModeLevelBlueprint blueprint) : base(blueprint)
        {
        }

        protected override void Setup(SpriteModeGameField gameField)
        {
            
        }
    }
}