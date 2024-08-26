
using CraftingModule.Core;

public interface IPickupable
{
    public IResource GetResource();
    public void SetResource(IResource resource);
}
