using UnityEngine;

[CreateAssetMenu(fileName = "NewStorageType", menuName = "We Won't Hunger/Storage Type")]
public class StorageTypeData : ScriptableObject
{
    [Header("Info")]
    public string StorageName;

    [Header("Settings")]
    public int MaxStock = 500;
}