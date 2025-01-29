using Entitas;
using UnityEngine;

public class CollisionSystem : IExecuteSystem
{
    readonly Contexts _contexts;

    public CollisionSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        
        var player = _contexts.game.GetGroup(GameMatcher.Player).GetSingleEntity();
        if (player == null) return; 

        
        var pads = _contexts.game.GetGroup(GameMatcher.Pad).GetEntities();

        foreach (var pad in pads)
        {
            
            if (Vector2.Distance(player.position.value, pad.position.value) < 0.5f)
            {
                
                pad.isTouched = true;
                Debug.Log($"Pad touched at position: {pad.position.value}");
            }
        }
    }
}
