
public class Bullet
{
    public Layer Layer_Out;
    public Layer Layer_Mid;
    public Layer Layer_Inn;
    public Effect Effect;


    public Bullet(Layer layer_Out, Layer layer_Mid, Layer layer_Inn, Effect effect)
    {
        Layer_Out = layer_Out;
        Layer_Mid = layer_Mid;
        Layer_Inn = layer_Inn;
        Effect = effect;
    }

    public (float, TypeElem) GiveOutLayerStats()
    {
        if (Layer_Out != null)
        {
            return (Layer_Out.Dmg, Layer_Out.Elem);
        }
        else return (0, null);
    }

    public (float, TypeElem) GiveMidLayerStats()
    {
        if(Layer_Mid != null) 
            return (Layer_Mid.Dmg, Layer_Mid.Elem);
        else return (0, null);
    }

    public (float, TypeElem) GiveInnLayerStats()
    {
        if (Layer_Inn != null)
            return (Layer_Inn.Dmg, Layer_Inn.Elem);
        else return (0, null);
    }

    public void GiveEffect(Unit Affected)
    {
        if (Effect != null)
        {
            Affected.Effect = Effect;
            Effect.SetAffected(Affected);
            Effect.gameObject.SetActive(true);
        }
    }
}
