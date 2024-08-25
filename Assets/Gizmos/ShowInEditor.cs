using UnityEngine;

namespace CraftingModule.OnGizmos
{
    /// <summary>
    /// Draw red sphere 
    /// </summary>
    
    [ExecuteInEditMode]
    public class ShowInEditor : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}

