using UnityEngine;

public class AgentNeeds : MonoBehaviour
{
    [Header("Data Source")]
    [SerializeField] private AgentTypeData _agentType;

    [Header("Live Stats")]
    [SerializeField] private float _currentHunger;

    // Public property to expose current hunger safely
    public float CurrentHunger => _currentHunger;

    private void Start()
    {
        // Initialize needs from the ScriptableObject data
        if (_agentType != null)
        {
            _currentHunger = _agentType.MaxHunger;
        }
    }

    private void Update()
    {
        if (_agentType == null)
            return; // Safety check

        // Decrease hunger over time using the rate from the data asset
        float decay = _agentType.HungerDecayRate * Time.deltaTime;
        _currentHunger = Mathf.Max(0, _currentHunger - decay);
    }

    /// <summary>
    /// Checks if the current hunger is below a given threshold.
    /// </summary>
    /// <param name="threshold">The value to compare hunger against.</param>
    /// <returns>True if current hunger is less than the threshold.</returns>
    public bool IsHungry(float threshold)
    {
        return _currentHunger < threshold;
    }

    /// <summary>
    /// Replenishes the agent's hunger by a specified amount.
    /// </summary>
    /// <param name="foodAmount">The amount of hunger to restore.</param>
    public void Eat(float foodAmount)
    {
        if (_agentType == null)
            return;

        _currentHunger += foodAmount;
        _currentHunger = Mathf.Min(_currentHunger, _agentType.MaxHunger);
    }
}