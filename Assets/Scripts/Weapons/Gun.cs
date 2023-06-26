using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public Base_Partical Particle;
    public Transform ShotPoint;
    public float DmgMulti;
    public float StartReloadTime;
    public Partical_Form Form;
    public Inventory Inventory;
    private float ReloadTime;
    


    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ+offset);

        if(ReloadTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Particle.Temp_DamageMulti = DmgMulti;
                Base_Partical Temp = Instantiate(Particle, ShotPoint.position, ShotPoint.rotation);
                Bullet TempBull = new Bullet();

                Layer tempLayerOut = new Layer();
                Layer tempLayerMid = new Layer();
                Layer tempLayerInn = new Layer();
                FillTempLayer(tempLayerOut, 4f, 0);
                FillTempLayer(tempLayerMid, 2f, 1);
                FillTempLayer(tempLayerInn, 1f, 2);
                FillTempBullet(TempBull, tempLayerOut, tempLayerMid, tempLayerInn, ChooseEffect());
                Temp.Projectile = TempBull;
                if (tempLayerOut.Elem != null) Temp.GetComponent<SpriteRenderer>().color = tempLayerOut.Elem.color;

                //print($"{Inventory.Slots[0].GetComponentInChildren<El_Type>().color}");
                //print(Temp.Projectile.Layer_Inn.Dmg);
                //print(Temp.Projectile.Layer_Mid.Dmg);
                //print(Temp.Projectile.Layer_Out.Dmg);
                //print("________________________________________");

                ReloadTime = StartReloadTime;

            }
        }
        else
        {
            ReloadTime -= Time.deltaTime;
        }
    }

    private Effect ChooseEffect()
    {
        
        
        El_Type Out = Inventory.Slots[0].GetComponentInChildren<El_Type>();
        El_Type Mid = Inventory.Slots[1].GetComponentInChildren<El_Type>();
        El_Type Inn = Inventory.Slots[2].GetComponentInChildren<El_Type>();
        if (Out == null) {
            return null;
        }
        Effect effect = new GameObject("TempEffect").AddComponent<Effect>();
        effect.gameObject.SetActive(false);
        effect.Elem = Inn;

        if (Out != null && Mid != null && Inn != null)
        {

            string CodeEffect = Out.Num_El.ToString() + Mid.Num_El.ToString() + Inn.Num_El.ToString();
            switch (CodeEffect)
            {
                case "000":
                    effect.Type = Effect.EffectType.Fire;
                    effect.time = 5;
                    effect.Multi = 8;
                    break;
                case "004":
                    effect.Type = Effect.EffectType.Geo;
                    effect.time = 5;
                    effect.Multi = 0.25f;
                    break;
                case "040":
                    effect.Type = Effect.EffectType.Fire;
                    effect.time = 5;
                    effect.Multi = 2;
                    break;
                case "044":
                    effect.Type = Effect.EffectType.Geo;
                    effect.time = 5;
                    effect.Multi = 0.5f;
                    break;
                case "400":
                    effect.Type = Effect.EffectType.Fire;
                    effect.time = 5;
                    effect.Multi = 2;
                    break;
                case "404":
                    effect.Type = Effect.EffectType.Geo;
                    effect.time = 5;
                    effect.Multi = 0.25f;
                    break;
                case "440":
                    effect.Type = Effect.EffectType.Fire;
                    effect.time = 5;
                    effect.Multi = 2;
                    break;
                case "444":
                    effect.Type = Effect.EffectType.Geo;
                    effect.time = 8;
                    effect.Multi = 0.55f;
                    break;
            }

        }
        else if (Out != null && Mid != null)
        {
            string CodeEffect = Out.Num_El.ToString() + Mid.Num_El.ToString();
            switch (CodeEffect)
            {
                case "00":
                    effect.Type = Effect.EffectType.Fire;
                    effect.time = 1;
                    effect.Multi = 2;
                    break;
                case "04":
                    effect.Type = Effect.EffectType.Geo;
                    effect.time = 2;
                    effect.Multi = 0.25f;
                    break;
                case "40":
                    effect.Type = Effect.EffectType.Fire;
                    effect.time = 2;
                    effect.Multi = 1;
                    break;
                case "44":
                    effect.Type = Effect.EffectType.Geo;
                    effect.time = 4;
                    effect.Multi = 0.5f;
                    break;
            }
        }
        return effect;
    }

    private void FillTempLayer(Layer layer, float dmg, int slotNum)
    {
        layer.Elem = Inventory.Slots[slotNum].GetComponentInChildren<El_Type>();
        layer.Dmg = dmg;
    }

    private void FillTempBullet(Bullet bullet ,Layer outL, Layer midL, Layer innL, Effect effect)
    {
        bullet.Layer_Out = outL;
        bullet.Layer_Mid = midL;
        bullet.Layer_Inn = innL;
        bullet.SetEffect(effect);
    }
}
