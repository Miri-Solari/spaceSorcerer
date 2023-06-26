using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControlMilieAi : MonoBehaviour
{
    public Transform target; // Цель противника (обычно игрок)
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Установить цель навигационному агенту
            navMeshAgent.SetDestination(target.position);
        }
    }
}
