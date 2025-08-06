using UnityEngine;

public class ResourceStorage : MonoBehaviour
{
    [Header("Data Source")]
    [SerializeField] private StorageTypeData _storageType;

    [Header("Live Stats")]
    [SerializeField] private int _currentStock;

    private void Start()
    {
        // Let's start with some food in storage for our tests.
        _currentStock = 100;
    }

    /// <summary>
    /// Attempts to remove a specified amount of food from storage.
    /// </summary>
    /// <param name="amount">The amount of food requested.</param>
    /// <returns>The amount of food actually taken.</returns>
    public int TakeFood(int amount)
    {
        int foodTaken = Mathf.Min(amount, _currentStock);
        _currentStock -= foodTaken;
        return foodTaken;
    }
}