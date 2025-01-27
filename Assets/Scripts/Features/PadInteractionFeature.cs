using Entitas;

public class PadInteractionFeature : Feature
{
    public PadInteractionFeature(Contexts contexts)
    {
        Add(new PadInteractionSystem(contexts));
    }
}
