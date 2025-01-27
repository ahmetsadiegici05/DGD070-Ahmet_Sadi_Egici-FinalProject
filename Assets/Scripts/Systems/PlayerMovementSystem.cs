using Entitas;
using UnityEngine;

public class PlayerMovementSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _players;

    public PlayerMovementSystem(Contexts contexts)
    {
        _players = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position, GameMatcher.Velocity));
    }

    public void Execute()
    {
        foreach (var player in _players.GetEntities())
        {
            var velocity = Vector2.zero;

            if (Input.GetKey(KeyCode.W)) velocity.y += 1;
            if (Input.GetKey(KeyCode.S)) velocity.y -= 1;
            if (Input.GetKey(KeyCode.A)) velocity.x -= 1;
            if (Input.GetKey(KeyCode.D)) velocity.x += 1;

            velocity = velocity.normalized * 5f;
            var newPosition = player.position.position + velocity * Time.deltaTime;

            newPosition.x = Mathf.Clamp(newPosition.x, -8f, 8f);
            newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

            player.ReplacePosition(newPosition);
        }
    }
}
