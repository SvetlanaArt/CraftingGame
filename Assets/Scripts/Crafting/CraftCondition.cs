using System.Collections.Generic;
using CraftingModule.Core;
using CraftingModule.Items;
using UnityEngine;
using UnityEngine.Events;

namespace CraftingModule.Crafting
{
    /// <summary>
    /// Contain crafting condition
    /// </summary>
    [System.Serializable]
    public class CraftCondition: ICraftable
    {
        [SerializeField] Item craftingItem;
        [Range(0, 100)]
        [SerializeField] int successChance;
        [SerializeField] Item source1Item;
        [SerializeField] Item source2Item;

       

        public IResource GetCraftingItem()
        {
            return craftingItem;
        }

        public List<IResource> GetReources()
        {
            List<IResource> resources = new List<IResource>();
            resources.Add(source1Item);
            resources.Add(source2Item);
            return resources;
        }

        public bool TryCraft()
        {
            bool success = Random.Range(0, 100) < successChance;

            return success;
        }

    }
}

