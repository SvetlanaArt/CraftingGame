using System;
using CraftingModule.Core;
using UnityEngine;

namespace CraftingModule.Items
{
    /// <summary>
    /// Contain item presentation resources
    /// </summary>
    [CreateAssetMenu(fileName = "Item", menuName = "Configuration/Item", order = 0)]
    public class Item: ScriptableObject, IResource
    {
        [SerializeField] string textName;
        [SerializeField] Sprite image;
        [SerializeField] GameObject prefab;

        private string id;

        public Item()
        {
            id = Guid.NewGuid().ToString();
        }

        public string GetId()
        {
            return id;
        }

        public GameObject GetPrefab()
        {
            return prefab;
        }

        public Sprite GetSprite()
        {
            return image;
        }
    }

}

