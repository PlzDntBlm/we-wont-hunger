using UnityEngine;

public class ResourceStorage : MonoBehaviour
{
    [Header("Storage Settings")]
    [SerializeField] private int _maxStock = 250;

    [Header("Live Stats")]
    [SerializeField] private int _currentStock;

    private void Start()
    {
        // Let's start with some food in storage for our tests.
        _currentStock = 100;
    }
}