using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(AgentNeeds))]
public class AgentAI : MonoBehaviour
{
    [Header("AI Settings")]
    [SerializeField] private float _hungerThreshold = 50f;
    [SerializeField] private Transform _granaryTransform;
    [SerializeField] private ResourceStorage _granaryStorage;

    private NavMeshAgent _navMeshAgent;
    private AgentNeeds _needs;
    private int _foodToTake = 50;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _needs = GetComponent<AgentNeeds>();
    }

    private void Update()
    {
        if (_needs.IsHungry(_hungerThreshold))
        {
            _navMeshAgent.SetDestination(_granaryTransform.position);

            if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                int foodTaken = _granaryStorage.TakeFood(_foodToTake);
                if (foodTaken > 0)
                {
                    _needs.Eat(foodTaken);
                    Debug.Log($"Agent ate {foodTaken} food.");
                }
            }
        }
    }
}