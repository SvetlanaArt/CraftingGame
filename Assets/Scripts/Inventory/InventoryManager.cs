using System;
using System.Collections.Generic;
using CraftingModule.Core;

namespace CraftingModule.Inventory
{

    /// <summary>
    /// Manage Inventory
    /// </summary>
    public class InventoryManager
    {
        public event Action<IResource, int> OnCountChange;

        private Dictionary<IResource, InventoryItem> storedItems = new Dictionary<IResource, InventoryItem>();

        public void Add(IResource item)
        {
            if (storedItems.TryGetValue(item, out InventoryItem inventoryItem))
            {
                inventoryItem.Add();
            }
            else
            {
                inventoryItem = new InventoryItem();
                storedItems.Add(item, inventoryItem);
            }
            OnCountChange?.Invoke(item, inventoryItem.Count);
        }

        public void Remove(IResource item)
        {
            if (storedItems.TryGetValue(item, out InventoryItem inventoryItem))
            {
                inventoryItem.Remove();
                if (inventoryItem.Count <= 0)
                {
                    storedItems.Remove(item);
                }
                OnCountChange?.Invoke(item, inventoryItem.Count);
            }
        }
    }
}


