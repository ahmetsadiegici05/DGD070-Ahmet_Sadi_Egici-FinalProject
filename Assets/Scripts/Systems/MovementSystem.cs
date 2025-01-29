using Entitas;
using UnityEngine;

public class MovementSystem : IExecuteSystem
{
    private readonly IGroup<InputEntity> _inputGroup;
    private readonly IGroup<GameEntity> _movableGroup;

    readonly float minX, maxX, minY, maxY; 

    public MovementSystem(Contexts contexts)
    {
        _inputGroup = contexts.ýnput.GetGroup(InputMatcher.Input);
        _movableGroup = contexts.game.GetGroup(GameMatcher.Movable);

        
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        minX = -screenBounds.x;
        maxX = screenBounds.x;
        minY = -screenBounds.y;
        maxY = screenBounds.y;
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

            
            position.x = Mathf.Clamp(position.x, minX + 0.1f, maxX - 0.1f);  
            position.y = Mathf.Clamp(position.y, minY + 0.1f, maxY - 0.1f);

            
            e.ReplacePosition(position);
        }
    }
}
