using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CraftingModule.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CraftingModule.UI.Crafting
{
    /// <summary>
    /// Manage crafting selection on UI and invoke crafting process
    /// </summary>

    public class UICrafting : MonoBehaviour
    {
        [SerializeField] UICraftingView craftingView;
        [SerializeField] Transform selectionParent;
        [SerializeField] ToggleGroup toggleselectionGroup;
        [SerializeField] GameObject craftingSelectionPrefab;
        
        public event Action<ICraftable> OnCraft;

        private UIItemSelection currentSelection;

        private Dictionary<UIItemSelection, ICraftable> craftingItems = new Dictionary<UIItemSelection, ICraftable>();

        public void Init(ReadOnlyCollection<ICraftable> craftings)
        {
            craftingView.InitResourceImages();
            craftingView.AddCraftButtonListener(Craft);

            InitCraftingItems(craftings);
        }

        private void InitCraftingItems(ReadOnlyCollection<ICraftable> craftings)
        {
            bool isOn = true;
            foreach (var crafting in craftings)
            {
                GameObject item = Instantiate(craftingSelectionPrefab, selectionParent);
                if (item == null)
                    continue;
                UIItemSelection itemSelection = item.GetComponent<UIItemSelection>();
                if (itemSelection != null)
                {
                    craftingItems.Add(itemSelection, crafting);
                    Sprite sprite = crafting.GetCraftingItem().GetSprite();
                    int count = crafting.GetReources().Count;
                    itemSelection.Init(sprite, count, toggleselectionGroup, isOn);
                    itemSelection.OnSelect += SelectCrafting;
                    isOn = false;
                }
            }
            if (craftingItems.Count > 0)
                SelectCrafting(craftingItems.Keys.First());
        }

        public void SelectCrafting(UIItemSelection itemSelection)
        {
            if (craftingItems.TryGetValue(itemSelection, out ICraftable crafting))
            {
                currentSelection = itemSelection;
                craftingView.SetSelection(crafting);
            }
            
            craftingView.UpdateCraftResult(false, false);
            craftingView.UpdateView(currentSelection);
        }

        public void Craft()
        {
            if (craftingItems.TryGetValue(currentSelection, out ICraftable craftable))
            {
                OnCraft?.Invoke(craftable);
            }
        }

        public void UpdateResourceAvailability(IResource resource, int count)
        {
            foreach (var crafting in craftingItems)
            {
                List<IResource> resources = crafting.Value.GetReources();
                int allCount = count;
                for (int i = 0; i < resources.Count; i++)
                {
                    if (resources[i] == resource)
                    {
                        crafting.Key.SetResourceAvailability(i, allCount > 0);
                        allCount--;
                    }
                }
            }

            craftingView.UpdateView(currentSelection);
        }

        public void UpdateCraftingResult(bool isSuccess)
        {
            craftingView.UpdateCraftResult(isSuccess, true);
        }
    }
}