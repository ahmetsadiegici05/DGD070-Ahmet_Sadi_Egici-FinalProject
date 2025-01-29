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
        int touchedPads = 0; 

        foreach (var pad in pads)
        {
            if (Vector2.Distance(player.position.value, pad.position.value) < 0.5f)
            {
                if (!pad.isTouched)
                {
                    pad.isTouched = true;
                    Debug.Log("Pad Touched!");

                    
                    if (pad.hasView)
                    {
                        var spriteRenderer = pad.view.gameObject.GetComponent<SpriteRenderer>();
                        if (spriteRenderer != null)
                        {
                            spriteRenderer.color = Color.green;
                        }
                    }
                }
            }

            if (pad.isTouched) touchedPads++; 
        }

        
        if (touchedPads == pads.Length)
        {
            Debug.Log(" WINRAR ÝS YOU ");

            
            player.Destroy();
        }
    }
}

