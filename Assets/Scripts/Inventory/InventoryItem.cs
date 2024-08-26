
namespace CraftingModule.Inventory
{
    /// <summary>
    /// Count inventory items of one type 
    /// </summary>

    public class InventoryItem
    {
        public int Count { get; private set; }

        public InventoryItem()
        {
            Count = 1;
        }

        public void Add()
        {
            Count++;
        }

        public void Remove()
        {
            Count--;
        }

    }

}
