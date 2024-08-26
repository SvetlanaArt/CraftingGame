using CraftingModule.Player;
using UnityEngine;

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
