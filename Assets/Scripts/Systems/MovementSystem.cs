using Entitas;
using UnityEngine;

public class MovementSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _movableGroup;
    private readonly InputContext _inputContext;

    public MovementSystem(Contexts contexts)
    {
        _movableGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Movable, GameMatcher.Position));
        _inputContext = contexts.ýnput;
    }

    public void Execute()
    {
        var inputEntity = _inputContext.GetGroup(InputMatcher.Input).GetSingleEntity();

        if (inputEntity != null)
        {
            float horizontal = inputEntity.ýnput.horizontal;
            float vertical = inputEntity.ýnput.vertical;

            foreach (var entity in _movableGroup.GetEntities())
            {
                var position = entity.position.value;
                position.x += horizontal * Time.deltaTime;
                position.y += vertical * Time.deltaTime;

                entity.ReplacePosition(position);
            }
        }
    }
}
