using System.Collections.Generic;
using CraftingModule.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CraftingModule.UI.Crafting
{

    /// <summary>
    /// Implement changing in view
    /// </summary>
    public class UICraftingView : MonoBehaviour
    {
        [Header("Crafting view")]
        [SerializeField] Image craftingItem;
        [SerializeField] Image resourceItem1;
        [SerializeField] Image resourceItem2;
        [Range(0, 1)]
        [SerializeField] float imageDisabledAlfa;
        [SerializeField] Button craftButton;
        [SerializeField] TMP_Text resultMessage;
        [Header("Messages")]
        [SerializeField] string successText;
        [SerializeField] string faildText;


        private List<Image> resourceImages = new List<Image>();

        public void InitResourceImages()
        {
            resourceImages.Add(resourceItem1);
            resourceImages.Add(resourceItem2);
        }

        public void AddCraftButtonListener(UnityAction action)
        {
            craftButton.onClick.AddListener(action);
        }

        public void SetSelection(ICraftable crafting)
        {
            craftingItem.sprite = crafting.GetCraftingItem().GetSprite();
            List<IResource> resources = crafting.GetReources();
            if (resources.Count >= resourceImages.Count)
            {
                for (int i = 0; i < resourceImages.Count; i++)
                {
                    resourceImages[i].sprite = resources[i].GetSprite();
                }
            }
        }

        public void UpdateView(UIItemSelection currentSelection)
        {
            bool isAllAvailable = true;
            for (int i = 0; i < resourceImages.Count; i++)
            {
                bool isAvailable = currentSelection.GetResourceAvailability(i);
                ChangeAlfa(resourceImages[i], isAvailable);
                isAllAvailable = isAllAvailable && isAvailable;
            }
            craftButton.interactable = isAllAvailable;
        }

        public void UpdateCraftResult(bool isSuccess, bool isResult)
        {
            ChangeAlfa(craftingItem, isSuccess);
            string message = "";
            if (isResult)
            {
                message = isSuccess ? successText : faildText;
            }
            resultMessage.text = message;

        }

        private void ChangeAlfa(Image image, bool isActive)
        {
            float alpha = isActive ? 1 : imageDisabledAlfa;
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }

    }
}