using CraftingModule.Core;
using CraftingModule.Items;
using UnityEngine;

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
}
