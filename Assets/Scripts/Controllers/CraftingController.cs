using System;
using System.Collections.Generic;
using CraftingModule.Core;
using CraftingModule.Crafting;
using CraftingModule.UI.Crafting;
using UnityEngine;

namespace CraftingModule.Controllers
{
    /// <summary>
    /// Control crafting logic and UI
    /// </summary>

    public class CraftingController : MonoBehaviour
    {
        [SerializeField] CraftingConfig craftingConfig;
        [SerializeField] UICrafting uiCrafting;

        public event Action<IResource> OnItemCreated;
        public event Action<IResource> OnItemUsed;

        public void UpdateResources(IResource resource, int count)
        {
            uiCrafting.UpdateResourceAvailability(resource, count);
        }

        private void Start()
        {
            uiCrafting.Init(craftingConfig.GetCraftingItems());
            uiCrafting.OnCraft += TryCraft;
        }

        private void TryCraft(ICraftable craftable)
        {
            bool isSuccess = craftable.TryCraft();
            uiCrafting.UpdateCraftingResult(isSuccess);

            if (isSuccess)
            {
                OnItemCreated?.Invoke(craftable.GetCraftingItem());
            }

            List<IResource> resources = craftable.GetReources();
            foreach (var resource in resources)
            {
                OnItemUsed?.Invoke(resource);
            }
        }
    }

}

