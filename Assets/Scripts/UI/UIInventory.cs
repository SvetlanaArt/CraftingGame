using System;
using System.Collections.Generic;
using CraftingModule.Core;
using UnityEngine;

namespace CraftingModule.Ui
{
    /// <summary>
    /// Manage an inventory UI
    /// </summary>
    public class UIInventory : MonoBehaviour
    {
        [SerializeField] Transform itemsContainer;
        [SerializeField] GameObject itemPrefub;

        private Dictionary<string, UIItem> inventoryItems = new Dictionary<string, UIItem>();

        public event Action<IResource> OnDrop;

        public void ChangeItemCount(IResource item, int count)
        {
            string itemId = item.GetId();
            if (inventoryItems.TryGetValue(itemId, out UIItem uIItem))
            {
                if (count <= 0)
                {
                    inventoryItems.Remove(itemId);
                    Destroy(uIItem.gameObject);
                    return;
                }
                uIItem.ChangeCount(count);
                return;
            }
            CreatNewUIItem(item, count, itemId);
        }

        private void CreatNewUIItem(IResource item, int count, string itemId)
        {
            UIItem uIItemNew = Instantiate(itemPrefub, itemsContainer).GetComponent<UIItem>();
            if (uIItemNew != null)
            {
                uIItemNew.OnDrop += () => OnDrop?.Invoke(item);
                uIItemNew.Create(item.GetSprite(), count);
                inventoryItems.Add(itemId, uIItemNew);
            }
        }
    }
}


