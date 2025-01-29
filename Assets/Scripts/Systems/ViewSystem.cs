using Entitas;
using UnityEngine;

public class ViewSystem : IExecuteSystem
{
    readonly GameContext _context;

    public ViewSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        foreach (var e in _context.GetEntities())
        {
            if (e.hasPosition && e.hasView)
            {
                e.view.gameObject.transform.position = new Vector3(e.position.value.x, e.position.value.y, 0);
            }
        }
    }
}
