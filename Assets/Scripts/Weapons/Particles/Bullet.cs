
public class Bullet
{
    public Layer Layer_Out;
    public Layer Layer_Mid;
    public Layer Layer_Inn;
    public Effect Effect;


    public (float, El_Type) GiveOutLayerStats()
    {
        if (Layer_Out != null)
        {
            return (Layer_Out.Dmg, Layer_Out.Elem);
        }
        else return (0, null);
    }

    public void SetLayerOutDmg(float dmg)
    {
        Layer_Out.Dmg = dmg;
    }

    public (float, El_Type) GiveMidLayerStats()
    {
        if(Layer_Mid != null) 
            return (Layer_Mid.Dmg, Layer_Mid.Elem);
        else return (0, null);
    }

    public (float, El_Type) GiveInnLayerStats()
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

    public void SetEffect(Effect effect)
    {
        Effect = effect;
    }



}
