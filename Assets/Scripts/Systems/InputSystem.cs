using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem
{
    private readonly InputContext _inputContext;

    public InputSystem(Contexts contexts)
    {
        _inputContext = contexts.�nput;
    }

    public void Execute()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        
        var inputEntity = _inputContext.GetGroup(InputMatcher.Input).GetSingleEntity();
        if (inputEntity == null)
        {
            inputEntity = _inputContext.CreateEntity();
            inputEntity.AddInput(horizontal, vertical);
        }
        else
        {
            inputEntity.ReplaceInput(horizontal, vertical);
        }
    }
}
