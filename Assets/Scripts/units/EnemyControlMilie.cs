using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlMilie : MonoBehaviour
{
    
    public float attackRange = 1f; // Дальность атаки противника
    public float damage = 10; // Урон атаки противника
    public El_Type DamageType;
    public float startReload;
    public float moveSpeed { get; private set; } // Скорость движения противника

    private Transform target; // Ссылка на игрока
    private Rigidbody2D rb;
    private Unit Self;
    private float Reload;


    private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока по тегу
        rb = GetComponent<Rigidbody2D>();
        Self = GetComponent<Unit>();
        
    }

    private void Update()
    {
        moveSpeed = Self.Speed;
        Vector2 direction = target.position - transform.position;

        // Проверяем дистанцию до игрока
        if (direction.magnitude > attackRange)
        {
            // Двигаемся в направлении игрока
            rb.velocity = direction.normalized * moveSpeed;
        }
        else
        {
            if (Reload <= 0)
            {
                Attack();
                Reload = startReload;
            }
            
        }
    }

    private void FixedUpdate()
    {
        if (Reload > 0)
        {
            Reload -= 0.2f;
        }

    }

    private void Attack()
    {
        target.GetComponent<Unit>().TakeDamege(damage, DamageType);
    }
}
