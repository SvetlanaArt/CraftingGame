using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CraftingModule.UI.Crafting
{
    /// <summary>
    /// Contain information of resource availability for selected item for crafting;
    /// </summary>
    public class UIItemSelection : MonoBehaviour
    {
        [SerializeField] Image itemImage;
        [SerializeField] Toggle toggle;

        public event Action<UIItemSelection> OnSelect;

        private List<bool> resourceAvailability = new List<bool>();

        public void Init(Sprite sprite, int resourceCount, ToggleGroup toggleGroup, bool isOn)
        {
            itemImage.sprite = sprite;
            InitResourceAvailability(resourceCount);
            toggle.group = toggleGroup;
            toggle.isOn = isOn;
        }

        public void Select()
        {
            if (toggle.isOn)
                OnSelect?.Invoke(this);
        }

        private void InitResourceAvailability(int resourceCount)
        {
            for (int i = 0; i < resourceCount; i++)
            {
                resourceAvailability.Add(false);
            }
        }

        public void SetResourceAvailability(int resourceNumber, bool isAvailable)
        {
            if (resourceAvailability.Count > resourceNumber)
                resourceAvailability[resourceNumber] = isAvailable;
        }

        public bool GetResourceAvailability(int resourceNumber)
        {
            return resourceAvailability.Count > resourceNumber && resourceAvailability[resourceNumber];
        }
    }

}
