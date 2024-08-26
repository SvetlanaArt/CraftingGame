using CraftingModule.Inventory;
using CraftingModule.Player;
using CraftingModule.Ui;
using UnityEngine;

namespace CraftingModule.Controllers
{
    /// <summary>
    /// Control interaction Ui Inventory, InventoryManager and Player
    /// </summary>

    public class InventoryController : MonoBehaviour
    {
        [SerializeField] PickUp playerPickUp;
        [SerializeField] Drop playerDrop;
        [SerializeField] UIInventory uIInventory;

        private InventoryManager inventoryManager;

        void Start()
        {
            inventoryManager = new InventoryManager();

            InitEvents();
        }

        private void InitEvents()
        {
            playerPickUp.OnPickup += inventoryManager.Add;
            inventoryManager.OnCountChange += uIInventory.ChangeItemCount;
            uIInventory.OnDrop += inventoryManager.Remove;
            uIInventory.OnDrop += playerDrop.DropItem;
        }
    }
}

