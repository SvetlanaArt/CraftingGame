using CraftingModule.Core;
using UnityEngine;
using UnityEngine.AI;

namespace CraftingModule.Player
{
    /// <summary>
    /// Player ability to drop an item near
    /// </summary>
    public class Drop : MonoBehaviour
    {
        [SerializeField] float distance;
        [SerializeField] float hight;
        [SerializeField] GameObject itemPrefab;
        [SerializeField] Transform itemsParent;
        [SerializeField] Transform PlayerParent;

        public void DropItem(IResource item)
        {
            Vector3 itemPosition;
            TryFindPosition(out itemPosition);

            CreateItem(item, itemPosition);
        }

        private bool TryFindPosition(out Vector3 itemPosition)
        {
            itemPosition = PlayerParent.position + Vector3.forward * distance;

            NavMeshHit hit;
            if (!NavMesh.SamplePosition(itemPosition, out hit, distance, NavMesh.AllAreas))
                return false;

            itemPosition = hit.position;
            itemPosition.y += hight;
            return true;
        }

        private void CreateItem(IResource item, Vector3 itemPosition)
        {
            IPickupable pickupableItem = Instantiate(itemPrefab,
                                                    itemPosition,
                                                    Quaternion.identity,
                                                    itemsParent)
                                                    .GetComponent<IPickupable>();
            if (pickupableItem != null)
            {
                pickupableItem.SetResource(item);
            }
        }
    }

}

