using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TopDownShooter.Inventory
{
    public class PlayerInventoryController : MonoBehaviour
    {
        [SerializeField]
        private AbstractBasePlayerInventoryItemData[] _inventoryItemDataArray;
        private List<AbstractBasePlayerInventoryItemData> _createdItemDataList;
        public Transform Parent;
        private void Start()
        {
            InitializeInventory(_inventoryItemDataArray);
        }
        private void OnDestroy()
        {
            ClearInventory();
        }
        public void InitializeInventory(AbstractBasePlayerInventoryItemData[] inventoryItemDataArray)
        {
            ClearInventory();
            _createdItemDataList = new List<AbstractBasePlayerInventoryItemData>(inventoryItemDataArray.Length);
            for (int i = 0; i < inventoryItemDataArray.Length; i++)
            {
                var instantiated = Instantiate(inventoryItemDataArray[i]);
                instantiated.CreateIntoInventory(this);
                _createdItemDataList.Add(instantiated);
            }
        }

        private void ClearInventory()
        {
            if (_createdItemDataList != null)
            {
                for (int i = 0; i < _createdItemDataList.Count; i++)
                {
                    _createdItemDataList[i].Destroy();
                }
            }
        }
    }
}
