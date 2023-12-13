using System.Xml.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public BasePartical Particle;
    public Transform ShotPoint;
    public float DmgMulti;
    private float startReloadTime;
    public ParticalForm Form;
    public Inventory Inventory;
    private float reloadTime;
    private bool isFlipped = false;


    private void Start()
    {
        startReloadTime = Form.Reload;
    }

    void Update()
    {
        TrackingCamera();
        if(reloadTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire(Form.CreateParticalStats(Particle.gameObject));
            }
        }
        else
        {
            reloadTime -= Time.deltaTime;
        }
    }

    private Effect ChooseEffect()
    {
        TypeElem Out = Inventory.Slots[0].GetComponentInChildren<TypeElem>();
        TypeElem Mid = Inventory.Slots[1].GetComponentInChildren<TypeElem>();
        TypeElem Inn = Inventory.Slots[2].GetComponentInChildren<TypeElem>();
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

    void Fire(float dmg)
    {
        Particle.ChangeDmgMilti(DmgMulti*dmg);
        BasePartical Temp = Instantiate(Particle, ShotPoint.position, ShotPoint.rotation);
        Layer tempLayerOut = new Layer(Inventory.Slots[0].GetComponentInChildren<TypeElem>(), 4f);
        Layer tempLayerMid = new Layer(Inventory.Slots[1].GetComponentInChildren<TypeElem>(), 2f);
        Layer tempLayerInn = new Layer(Inventory.Slots[2].GetComponentInChildren<TypeElem>(), 1f);
        Bullet TempBull = new Bullet(tempLayerOut, tempLayerMid, tempLayerInn, ChooseEffect());
        Temp.Projectile = TempBull;
        if (tempLayerOut.Elem != null) Temp.GetComponent<SpriteRenderer>().color = tempLayerOut.Elem.Color;
        reloadTime = startReloadTime;
    }

    void TrackingCamera()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        Flip();
    }

    void Flip()
    {
        bool needToMirror = transform.rotation.eulerAngles.z > 90f && transform.rotation.eulerAngles.z < 270f;
        if (needToMirror && isFlipped == false)
        {
         
            transform.localScale = new Vector3(transform.localScale.x, -1 * transform.localScale.y, transform.localScale.z);
            isFlipped = true;
        }
        else if (isFlipped && needToMirror == false)
        {
            transform.localScale = new Vector3(transform.localScale.x, -1 * transform.localScale.y, transform.localScale.z);
            isFlipped = false;
        }
    }
}
