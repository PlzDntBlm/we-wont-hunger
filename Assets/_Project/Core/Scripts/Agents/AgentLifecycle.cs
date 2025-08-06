using UnityEngine;

[RequireComponent(typeof(AgentNeeds))]
public class AgentLifecycle : MonoBehaviour
{
    [Header("Data Source")]
    [SerializeField] private AgentTypeData _agentType;

    [Header("Live Stats")]
    [SerializeField] private float _currentAge = 0f;
    [SerializeField] private float _currentHealth;

    private void Start()
    {
        if (_agentType != null)
        {
            _currentHealth = _agentType.MaxHealth;
        }
    }

    private void Update()
    {
        if (_agentType == null)
            return;

        _currentAge += Time.deltaTime;

        // Check if the agent has exceeded its lifespan
        if (_currentAge > _agentType.Lifespan)
        {
            Die();
        }
    }

    /// <summary>
    /// Handles the death of the agent.
    /// </summary>
    private void Die()
    {
        Debug.Log($"{_agentType.AgentName} has died of old age.");
        Destroy(gameObject); // Removes the agent from the scene
    }
}