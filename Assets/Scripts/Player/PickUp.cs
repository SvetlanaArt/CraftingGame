using System;
using CraftingModule.Core;
using UnityEngine;

namespace CraftingModule.Player
{
    /// <summary>
    /// Pick up items
    /// </summary>
    public class PickUp : MonoBehaviour
    {

        public event Action<IResource> OnPickup;

        private void OnTriggerEnter(Collider other)
        {
            IPickupable item = other.gameObject.GetComponent<IPickupable>();
            if (item != null)
            {
                OnPickup?.Invoke(item.GetResource());
                
                Destroy(other.gameObject);
            }
        }
    }
}

