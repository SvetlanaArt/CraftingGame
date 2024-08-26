using System.Collections.Generic;

namespace CraftingModule.Core
{
    /// <summary>
    /// interface for craftable objects
    /// </summary>
    public interface ICraftable
    {
        public bool TryCraft();
        public List<IResource> GetReources();
        public IResource GetCraftingItem();

    }
}

