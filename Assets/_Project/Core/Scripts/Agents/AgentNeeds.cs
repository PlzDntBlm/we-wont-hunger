using UnityEngine;

public class AgentNeeds : MonoBehaviour
{
    [Header("Hunger Settings")]
    [SerializeField] private float _maxHunger = 100f;
    [SerializeField] private float _hungerDecayRate = 1f;

    [Header("Live Stats")]
    [SerializeField] private float _currentHunger;

    private void Start()
    {
        // Start with a full stomach
        _currentHunger = _maxHunger;
    }

    private void Update()
    {
        // Decrease hunger over time
        // We use Mathf.Max to ensure hunger doesn't drop below zero.
        _currentHunger = Mathf.Max(0, _currentHunger - _hungerDecayRate * Time.deltaTime);
    }
    public bool IsHungry(float threshold)
    {
        return _currentHunger < threshold;
    }

    public void Eat(float foodAmount)
    {
        _currentHunger += foodAmount;
        _currentHunger = Mathf.Min(_currentHunger, _maxHunger);
    }
}