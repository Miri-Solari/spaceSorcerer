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
        transform.Translate(Vector2.up * Speed);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            
            collision.collider.GetComponent<Unit>().TakeDamege(Damage, Projectile.);
            Destroy(gameObject);
        }

    }

}
