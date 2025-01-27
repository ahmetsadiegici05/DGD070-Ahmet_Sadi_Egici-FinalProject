using Entitas;
using UnityEngine;

public class WinConditionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _pads;
    private readonly Contexts _contexts;

    public WinConditionSystem(Contexts contexts)
    {
        _contexts = contexts;
        _pads = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Pad, GameMatcher.PadTouched));
    }

    public void Execute()
    {
        if (_pads.count == 4)
        {
            _contexts.game.isWin = true;
            Debug.Log("A WINRAR IS YOU");
        }
    }
}
