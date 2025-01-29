using Entitas;
using UnityEngine;

public class MovementSystem : IExecuteSystem
{
    private readonly IGroup<InputEntity> _inputGroup;
    private readonly IGroup<GameEntity> _movableGroup;

    public MovementSystem(Contexts contexts)
    {
        _inputGroup = contexts.ýnput.GetGroup(InputMatcher.Input);
        _movableGroup = contexts.game.GetGroup(GameMatcher.Movable);
    }

    public void Execute()
    {
        var inputEntity = _inputGroup.GetSingleEntity();
        if (inputEntity == null || !inputEntity.hasInput)
        {
            return; 
        }

        var input = inputEntity.ýnput;

        foreach (var e in _movableGroup.GetEntities())
        {
            var position = e.position.value;

            
            position.x += input.horizontal * Time.deltaTime * 5f; 
            position.y += input.vertical * Time.deltaTime * 5f;

            e.ReplacePosition(position);
            
        }
    }
}
