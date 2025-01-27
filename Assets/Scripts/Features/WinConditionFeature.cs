using Entitas;

public class WinConditionFeature : Feature
{
    public WinConditionFeature(Contexts contexts)
    {
        Add(new WinConditionSystem(contexts));
    }
}
