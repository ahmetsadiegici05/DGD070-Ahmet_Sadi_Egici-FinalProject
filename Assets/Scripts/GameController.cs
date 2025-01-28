using Entitas;
using UnityEngine;


public class GameController : MonoBehaviour
{
    Systems _systems;

    void Start()
    {
        var contexts = Contexts.sharedInstance;

      
        _systems = new Feature("Game Systems")
            .Add(new InputSystem(contexts))
            .Add(new MovementSystem(contexts))
            .Add(new CollisionSystem(contexts))
            .Add(new WinConditionSystem(contexts));

        _systems.Initialize();

        
        CreatePlayer(contexts);
        CreatePads(contexts);
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    void CreatePlayer(Contexts contexts)
    {
        var player = contexts.game.CreateEntity();
        player.AddPosition(new Vector2(0, 0)); 
        player.isPlayer = true;
    }

    void CreatePads(Contexts contexts)
    {
        var padPositions = new Vector2[] {
            new Vector2(-4, -4),
            new Vector2(4, -4),
            new Vector2(-4, 4),
            new Vector2(4, 4)
        };

        foreach (var pos in padPositions)
        {
            var pad = contexts.game.CreateEntity();
            pad.AddPosition(pos);
            pad.isPad = true;
        }
    }
}
