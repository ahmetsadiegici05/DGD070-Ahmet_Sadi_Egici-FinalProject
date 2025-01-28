using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem
{
    private readonly InputContext _inputContext;

    public InputSystem(Contexts contexts)
    {
        _inputContext = contexts.ýnput;
    }

    public void Execute()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var inputEntity = _inputContext.CreateEntity();
        inputEntity.AddInput(horizontal, vertical); 
    }
}
