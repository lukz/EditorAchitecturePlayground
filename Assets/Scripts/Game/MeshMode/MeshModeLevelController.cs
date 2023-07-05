using Game.Core.Levels;

namespace Game.MeshMode
{
    public class MeshModeLevelController : LevelController<MeshModeLevelBlueprint, MeshModeGameField>
    {
        public MeshModeLevelController(MeshModeLevelBlueprint blueprint) : base(blueprint)
        {
        }

        protected override void Setup(MeshModeGameField gameField)
        {
            
        }
    }
}