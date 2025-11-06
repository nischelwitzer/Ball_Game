using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyFollowController : MonoBehaviour
{
    public Transform ballPlayer;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (ballPlayer != null)
        {
            navMeshAgent.SetDestination(ballPlayer.position);
        }
    }
}
