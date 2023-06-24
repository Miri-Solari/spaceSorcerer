using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Base_Partical : MonoBehaviour
{
    public float Temp_Speed;
    public float Temp_Lifetime;
    public float Temp_DamageMulti;
    public Bullet Projectile;
    public float slowdown;

    private float Speed;
    private float Lifetime;
    private float DamageMulti;



    private void Start()
    {

        Speed = Temp_Speed/10;
        Lifetime = Temp_Lifetime;
        DamageMulti = Temp_DamageMulti;
    }

    private void Update()
    {
        Lifetime -= Time.deltaTime;
        Speed -= Time.deltaTime * slowdown/500;
        if (Speed < 0 | Lifetime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * Speed);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            Unit Attacked = collision.collider.GetComponent<Unit>();
            GiveDamage(Attacked);
            Influence(Attacked);
            Destroy(gameObject);
            
        }

    }


    private void GiveDamage(Unit TakenDamage)
    {
        (float, El_Type) temp = Projectile.GiveOutLayerStats();
        print(temp.Item2);

        TakenDamage.TakeDamege(temp.Item1 * DamageMulti, temp.Item2);
        print(temp.Item2);
        temp = Projectile.GiveMidLayerStats();
        TakenDamage.TakeDamege(temp.Item1 * DamageMulti, temp.Item2);
        temp = Projectile.GiveInnLayerStats();
        print(temp.Item2);
        TakenDamage.TakeDamege(temp.Item1 * DamageMulti, temp.Item2);
        print("_________");
    }
    private void Influence(Unit Affected)
    {

    }

}
