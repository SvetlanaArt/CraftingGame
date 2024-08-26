using System;
using CraftingModule.Core;
using UnityEngine;
using UnityEngine.Events;

namespace CraftingModule.Player
{
    /// <summary>
    /// Pick up items
    /// </summary>
    public class PickUp : MonoBehaviour
    {
        [SerializeField] UnityEvent OnPickUpEffects;

        public event Action<IResource> OnPickup;

        private void OnTriggerEnter(Collider other)
        {
            IPickupable item = other.gameObject.GetComponent<IPickupable>();
            if (item != null)
            {
                OnPickup?.Invoke(item.GetResource());
                OnPickUpEffects?.Invoke();

                Destroy(other.gameObject);
            }
        }
    }
}

