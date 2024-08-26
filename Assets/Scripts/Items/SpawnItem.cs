using CraftingModule.Core;
using UnityEngine;

namespace CraftingModule.Items
{
    /// <summary>
    /// Spawn Item
    /// </summary>

    public class SpawnItem : MonoBehaviour, IPickupable
    {
        [SerializeField] Item item;

        private void Start()
        {
            Instantiate(item.GetPrefab(), transform);
        }

        public IResource GetResource()
        {
            return item;
        }

        public void SetResource(IResource resource)
        {
            item = (Item)resource;
        }
    }
}

