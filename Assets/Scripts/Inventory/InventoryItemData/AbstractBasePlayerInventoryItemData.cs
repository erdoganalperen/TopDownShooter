using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Inventory
{
    public abstract class AbstractBasePlayerInventoryItemData : ScriptableObject
    {
        protected PlayerInventoryController _inventoryController;
        protected CompositeDisposable _compositDisposable;
        public virtual void Initialize(PlayerInventoryController targetPlayerIventory)
        {
            _inventoryController = targetPlayerIventory;
            _compositDisposable = new CompositeDisposable();
        }

        public virtual void Destroy()
        {
            //unsubscribing from all events added to this
            _compositDisposable.Dispose();
            Destroy(this);
        }
    }
}
