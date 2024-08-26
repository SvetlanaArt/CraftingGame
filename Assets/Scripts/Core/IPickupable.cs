
namespace CraftingModule.Core
{
    /// <summary>
    /// Interface for pick-up objects
    /// </summary>
    public interface IPickupable
    {
        public IResource GetResource();
        public void SetResource(IResource resource);
    }
}
