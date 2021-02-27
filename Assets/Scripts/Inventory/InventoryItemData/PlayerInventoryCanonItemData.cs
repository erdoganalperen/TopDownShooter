using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Inventory/Player Inventory Canon Item Data")]
    public class PlayerInventoryCanonItemData : AbstractPlayerInventoryItemData<PlayerInventoryCanonItemMono>
    {
        public override void CreateIntoInventory(PlayerInventoryController targetPlayerIventory)
        {
            var instantiated = InstantiateAndInitializePrefab(targetPlayerIventory.Parent);
            Debug.Log("canonitemdata");

        }
    }
}
