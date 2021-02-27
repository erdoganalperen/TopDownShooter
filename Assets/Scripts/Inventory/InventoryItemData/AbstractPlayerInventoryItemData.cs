using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TopDownShooter.Inventory
{
    public enum InventoryItemDataType { Canon, Body }
    public abstract class AbstractPlayerInventoryItemData<T> : AbstractBasePlayerInventoryItemData where T : AbstractPlayerInventoryItemMono
    {
        [SerializeField] private string _itemId;
        [SerializeField] protected InventoryItemDataType _inventoryItemDataType;
        [SerializeField] protected T _prefab;

        protected T InstantiateAndInitializePrefab(Transform parent)
        {
            return Instantiate(_prefab, parent);
        }
    }
}
