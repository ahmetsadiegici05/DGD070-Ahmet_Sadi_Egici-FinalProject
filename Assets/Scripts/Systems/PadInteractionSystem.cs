using Entitas;
using UnityEngine;

public class PadInteractionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _pads;
    private readonly IGroup<GameEntity> _players;

    public PadInteractionSystem(Contexts contexts)
    {
        _pads = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Pad, GameMatcher.Position));
        _players = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position));
    }

    public void Execute()
    {
        foreach (var player in _players.GetEntities())
        {
            foreach (var pad in _pads.GetEntities())
            {
                if (Vector2.Distance(player.position.position, pad.position.position) < 0.5f)
                {
                    pad.isPadTouched = true; 
                }
            }
        }
    }
}
