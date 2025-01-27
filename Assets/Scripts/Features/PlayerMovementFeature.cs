using Entitas;

public class PlayerMovementFeature : Feature
{
    public PlayerMovementFeature(Contexts contexts)
    {
        Add(new PlayerMovementSystem(contexts));
    }
}
