using System.Collections.Generic;
using System.Collections.ObjectModel;
using CraftingModule.Core;
using UnityEngine;

namespace CraftingModule.Crafting
{

    /// <summary>
    /// Configurate crafting conditions
    /// </summary>
    [CreateAssetMenu(fileName = "CraftingConfig", menuName = "Configuration/CraftingConfig", order = 0)]
    public class CraftingConfig : ScriptableObject
    {
        [SerializeField] List<CraftCondition> craftingItems = new List<CraftCondition>();

        public ReadOnlyCollection<ICraftable> GetCraftingItems()
        {
            List<ICraftable> craftings = new List<ICraftable>();
            foreach (var crafting in craftingItems)
            {
                craftings.Add(crafting);
            }
            return craftings.AsReadOnly();
        }

    }

}