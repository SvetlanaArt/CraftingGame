using CraftingModule.Inventory;
using CraftingModule.Player;
using CraftingModule.UI.Inventory;
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
        [SerializeField] CraftingController craftingController;

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

            if (craftingController != null)
            {
                craftingController.OnItemCreated += inventoryManager.Add;
                craftingController.OnItemUsed += inventoryManager.Remove;
                inventoryManager.OnCountChange += craftingController.UpdateResources;
            }
        }
    }
}

