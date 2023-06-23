using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Base_Partical : MonoBehaviour
{
    public float Temp_Speed;
    public float Temp_Lifetime;
    public Vector2 Start_Direct;
    public float Temp_Damage;
    public Bullet Projectile;

    private float Speed;
    private float Lifetime;
    private float Damage;
    private Vector2 Direct;

    private void Start()
    {
        Speed = Temp_Speed;
        Lifetime = Temp_Lifetime;
        Damage = Temp_Damage;
        Direct = Start_Direct;
        
    }

    void Update()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast(transform.position, transform.up, );
    }

    private void FixedUpdate()
    {
        
    }

    
}
