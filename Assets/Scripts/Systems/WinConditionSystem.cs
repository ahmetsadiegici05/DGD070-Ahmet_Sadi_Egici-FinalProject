using Entitas;
using System.Linq;
using UnityEngine;

public class WinConditionSystem : IExecuteSystem
{
    readonly Contexts _contexts;

    public WinConditionSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        
        var pads = _contexts.game.GetGroup(GameMatcher.Pad).GetEntities();

        
        if (pads.Length > 0 && pads.All(pad => pad.isTouched))
        {
            Debug.Log(" Oyun Tamamlandý! ");
        }
    }
}
