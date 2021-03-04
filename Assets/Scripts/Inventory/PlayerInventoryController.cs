using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryController : MonoBehaviour
    {
        [SerializeField]
        private AbstractBasePlayerInventoryItemData[] _inventoryItemDataArray;
        private List<AbstractBasePlayerInventoryItemData> _createdItemDataList;
        public Transform BodyParent;
        public Transform CanonParent;

        public ReactiveCommand ReactiveShootCommand { get; private set; }
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
            if (ReactiveShootCommand != null)
            {
                //adjusting reactive command
                ReactiveShootCommand.Dispose();
            }
            ReactiveShootCommand = new ReactiveCommand();

            //clearing old inventory and create new one
            ClearInventory();
            _createdItemDataList = new List<AbstractBasePlayerInventoryItemData>(inventoryItemDataArray.Length);
            for (int i = 0; i < inventoryItemDataArray.Length; i++)
            {
                var instantiated = Instantiate(inventoryItemDataArray[i]);
                instantiated.Initialize(this);
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
