
using UnityEngine;

namespace CraftingModule.Core
{
    /// <summary>
    /// interface for craft resources
    /// </summary>
    public interface IResource
    {
        public string GetId();
        Sprite GetSprite();
    }

}

